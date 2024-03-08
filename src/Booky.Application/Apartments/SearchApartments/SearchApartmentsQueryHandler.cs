using Booky.Application.Abstractions.Data;
using Booky.Application.Abstractions.Messaging;
using Booky.Domain.Abstractions;
using Booky.Domain.Bookings;
using Dapper;

namespace Booky.Application.Apartments.SearchApartments;

internal sealed class SearchApartmentsQueryHandler : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
{
    private static readonly int[] ActiveBookingStatuses =
    [
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    ];

    private readonly ISqlConnectionFactory _connectionFactory;

    public SearchApartmentsQueryHandler(ISqlConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

    public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
            return new List<ApartmentResponse>();

        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
                           Select
                             a.id as Id,
                             a.name as Name,
                             a.description as Description,
                             a.price_amount as Price,
                             a.price_currency as Currency,
                             a.address_country as Country,
                             a.address_state as State,
                             a.address_zip_code as ZipCode,
                             a.address_city as City,
                             a.address_street a Street
                           From apartments as a
                           Where not exists
                           (
                             Select 1
                             From bookings as b
                             Where
                                 b.apartment_id = id and
                                 b.duration_start <= @EndDate and
                                 b.duration_end >= @StartDate and
                                 b.status = any(@ActiveBookingStatuses)
                           )
                           """;

        var apartments = await connection
            .QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                sql,
                (apartment, address) =>
                {
                    apartment.Address = address;
                    return apartment;
                },
                new
                {
                    request.StartDate,
                    request.EndDate,
                    ActiveBookingStatuses
                }, splitOn: "Country");

        return apartments.ToList();
    }
}