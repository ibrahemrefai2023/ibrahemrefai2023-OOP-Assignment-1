
public class Guest
{
    private readonly List<Reservation> _reservations = new();

    public int GuestId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }

    public IReadOnlyList<Reservation> Reservations =>
        _reservations.AsReadOnly();

    public Guest(
        int guestId,
        string fullName,
        string phoneNumber)
    {
        if (guestId <= 0)
            throw new ArgumentException(
                "Guest ID must be positive.");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException(
                "Guest full name cannot be empty.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException(
                "Guest phone number cannot be empty.");

        GuestId = guestId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public void AddReservation(Reservation reservation)
    {
        if (reservation is null)
            throw new ArgumentNullException(nameof(reservation));

        if (_reservations.Contains(reservation))
            throw new InvalidOperationException(
                "This reservation is already associated with the guest.");

        reservation.Room.AddReservation(reservation);

        _reservations.Add(reservation);
    }
}