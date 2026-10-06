public class Room
{
    private readonly List<Reservation> _reservations = new();

    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (roomNumber <= 0)
            throw new ArgumentException("Room number must be positive.");

        if (nightlyRate <= 0)
            throw new ArgumentException("Nightly rate must be greater than zero.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
    }

    public void ChangeNightlyRate(decimal newRate)
    {
        if (newRate <= 0)
            throw new ArgumentException("Nightly rate must be greater than zero.");

        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }

    public void AddReservation(Reservation reservation)
    {
        if (reservation is null)
            throw new ArgumentNullException(nameof(reservation));

        if (IsUnderMaintenance)
            throw new InvalidOperationException(
                "Cannot create a reservation for a room under maintenance.");

        if (reservation.Room != this)
            throw new InvalidOperationException(
                "This reservation does not belong to this room.");

        bool hasOverlap = _reservations.Any(existing =>
            IsActive(existing) &&
            reservation.CheckInDate < existing.CheckOutDate &&
            reservation.CheckOutDate > existing.CheckInDate);

        if (hasOverlap)
            throw new InvalidOperationException(
                "The room is already booked for the selected dates.");

        _reservations.Add(reservation);
    }

    private static bool IsActive(Reservation reservation)
    {
        return reservation.Status != ReservationStatus.Cancelled &&
               reservation.Status != ReservationStatus.CheckedOut;
    }
}