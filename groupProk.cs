#Web Development Project

Booking.cshtml.cs

[BindProperty(SopportsGet = TRUE)]
public Booking aBooking {get;set;}

public async Task OnPostAsync(){
	
}


#create a BookingViewModel class 

public int RoomID {get;set;}
[DataType(DataType.Date)]
public DateTime CheckIn {get;set;}
[DataType(DataType.Date)]
public DateTime CheckOut {get;set;}

#scaffold and create CURD pages

#Create.cshtml.cs file

[BindProperty]
public BookingViewModel theBooking {get;set;}

#OnPostAsync
Booking booking = new Booking();
booking.RoomID = theBooking.RoomID;
booking.CheckIn = theBooking.CheckOut;
booking.CheckOut = theBooking.CheckOut;

var theRoom = await _context.Room.FindAsync(theBooking.RoomID);
booking.Price = theRoom.Price;

var theCustomer = await _context.Customer.FindAsync(CustomerID);
booking.CustomerID = theCustomer.ID;

_context.Booking.Add(booking);
await _context.SaveChangesAsync();


#front end
 <form action="">
  <div class="form-group">
    <label for="theBooking.RoomID">Room ID:</label>
    <input asp-for = "theBooking.RoomID" class="form-control">
  </div>
  <div class="form-group">
    <label for="theBooking.CheckIn">Check In</label>
    <input asp-for = "theBooking.CheckIn" class="form-control">
  </div>
   <div class="form-group">
    <label for="theBooking.CheckOut">Check Out</label>
    <input asp-for = "theBooking.CheckOut" class="form-control">
  </div>
  <button type="submit" class="btn btn-default">Submit</button>
</form> 



#this one is just for practice
public IActionList<Movie> Movie;

