
#PMC
#check the version in .csproj file
Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version3.x.x

#Startup.cs
options.UseSqlite("Data Source= identity.db")

#Front-End
.
.
.
.

#Magzine.cs

public int ID {get;set;}
[Required]
public String Title{get;set;}
[DataType(DataType.Currency)]
public decimal Price{get;set;}

//Navigation Properties
public ICollection<Subscription> theSubscription {get;set;}

#Subscription.cs

public int ID{get;set;}
public int MagzineID{get;set;}
public String CustomerEmail {get;set;}
public int NumOfIssues {get;set;}
public decimal TotalCost {get;set;}

//These are the navigation properties
public Magzine theMagzine {get;set;}
public Customer theCustomer {get;set;}

#Customers.cs 
public String Email {get;set;}
public String LastName {get;set;}
public String FirstName {get;set;}
public DateTime DOB {get;set;}
public String Mobile {get;set;}
public String Postcode {get;set;}

public ICollection<Subscription> theSubscription {get;set;}

#SubscriptionViewModel.cs

public int MagzineID{get;set;}
public String MagzineTitle{get;set;}
public int NumOfIssues{get;set;}

# in the .cshtml.cs file  
[BindProperty(SupportsGet = true)]
public SubscriptionViewModel theSubscriptionModel {get;set;}

public IActionResult OnGet(){
	ViewData["MagzineList"] = new SelectList(_context.Magzine,"ID","Title");
	return Page();
}

public async Task <IActionResult> OnPostAsync(){
	subscription = new Subscription();
	subscription.MagzineID = theSubscriptionModel.MagzineID;
	subscription.CustomerEmail = xxxx;
	subscription.NumOfIssues  = theSubscriptionModel.NumOfIssues;

	var theMagzines = await _context.Magzine.FindAsync(subscription.MagzineID);
	subscription.TotalCost = theSubscriptionModel.NumOfIssues * theMagzine.Price;

	_context.Subscription.Add(subscription);
	await _context.Subscription.SaveChangesAsync();
	return Page();

}

#The Front-End from

 <form action="" method = "post">
  <div class="form-group">
    <label for="theSubscription.MagzineID">Magzine :</label>
    <select asp-for = "theSubscriptionModel.MagzineID" asp-items = "ViewBag.MagzineList" class="form-control">
  </div>
  <div class="form-group">
    <label for="theSubscriptionModel.NumOfIssues">Number of NumOfIssues:</label>
    <input asp-for = "theSubscriptionModel.NumOfIssues" class="form-control" >
  </div>
  <button type="submit" class="btn btn-default">Submit</button>
</form> 






