namespace Part2_HotelReservationSystem;
using System;

class Program
{
    static void Main(string[] args)
    {

        var room = new Room(
       roomNumber: 101,
       roomType: RoomType.Double,
       nightlyRate: 1500m);

        var guest = new Guest(
            guestId: 1,
            fullName: "Ibrahim Refeay",
            phoneNumber: "01012345678");

        var reservation = new Reservation(
            reservationId: 1001,
            checkInDate: new DateTime(2026, 10, 10),
            checkOutDate: new DateTime(2026, 10, 13),
            room: room);

        guest.AddReservation(reservation);

        reservation.Confirm();
        reservation.CheckIn();

        Console.WriteLine(reservation.Status);
        Console.WriteLine(reservation.NumberOfNights);
        Console.WriteLine(reservation.TotalCost);

        reservation.CheckOut();

        Console.WriteLine(reservation.Status);
        Console.ReadLine();
    }
}
