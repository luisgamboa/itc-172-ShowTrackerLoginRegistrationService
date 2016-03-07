using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShowTrackerLoginService" in code, svc and config file together.
public class ShowTrackerLoginService : IShowTrackerLoginService
{

    ShowTrackerEntities db = new ShowTrackerEntities();
	
	
    public int VenueLogin(string password, string username)
    {
        int result = db.usp_venueLogin(username, password);
        if (result != -1)
        {
            var key = from k in db.VenueLogins
                      where k.VenueLoginUserName.Equals(username)
                      select new { k.VenueLoginKey };
            foreach (var k in key)
            {
                result = (int)k.VenueLoginKey;
            }
        }

        return result;
    }

    public int VenueRegistration(VenueLite r)
    {
        int result = db.usp_RegisterVenue(r.VenueName, r.VenueAddress, r.VenueCity, r.VenueState, r.VenueZipCode, r.VenuePhone, r.VenueEmail, r.VenueWebPage, r.VenueAgeRestriction, r.VenueLoginUserName, r.VenueLoginPasswordPlain);

        return result;
    }

    public int AddShow(NewShow ns)
    {
        Show show = new Show();
        ShowDetail showDetail = new ShowDetail();

        show.ShowName = ns.ShowName;
        show.ShowDate = DateTime.Now;
        show.ShowDate = DateTime.Parse(ns.ShowDate);
        show.ShowTime = TimeSpan.Parse(ns.ShowTime);
        show.ShowTicketInfo = ns.ShowTicketInfo;
        show.ShowDateEntered = DateTime.Now;

        showDetail.Show = show;
        showDetail.ShowKey = int.Parse(ns.ShowKey);
        showDetail.ArtistKey = int.Parse(ns.ArtistKey);
        showDetail.ShowDetailAdditional = ns.ShowDetailAdditional;


        db.Shows.Add(show);
        db.SaveChanges();

        return 0;
        }
    
 

    public int AddArtist(NewArtist na)
    {
        
        Artist a = new Artist();
        a.ArtistName = na.ArtistName;
        a.ArtistEmail = na.ArtistEmail;
        db.Artists.Add(a);
        db.SaveChanges();

        return 0;
        
    }
   


}
