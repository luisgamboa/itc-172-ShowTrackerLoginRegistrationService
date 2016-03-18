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

    public int AddArtist(ArtistLite al)
    {
        int result = 1;
        Artist a = new Artist();
        a.ArtistName = al.ArtistName;
        a.ArtistEmail = al.ArtistEmail;
        a.ArtistWebPage = al.ArtistWebPage;
        a.ArtistDateEntered = DateTime.Now;


        try
        {

            db.Artists.Add(a);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            result = 0;
            throw ex;
        }

        return result;

    }

    public int FanLogin(string password, string username)
    {
        int result = db.usp_FanLogin(username, password);
        if (result != -1)
        {
            var key = from k in db.FanLogins
                      where k.FanLoginUserName.Equals(username)
                      select new { k.FanLoginKey };
            foreach (var k in key)
            {
                result = (int)k.FanLoginKey;
            }
        }

        return result;
    }

    public int FanRegistration(FanLite r)
    {
        int result = db.usp_RegisterFan(r.FanName, r.FanEmail, r.FanLoginUserName, r.FanLoginPasswordPlain);

        return result;
    }




    public int AddShow(ShowLite sl)
    {
        int result = 1;

        sl.VenueKey = 1;

        Show s = new Show();


        var vk = from v in db.Shows
                 where v.Venue.VenueName.Equals(sl.ShowName)
                 select new { v.VenueKey };

        s.VenueKey = sl.VenueKey;
        s.ShowName = sl.ShowName;
        s.ShowDate = sl.ShowDate;
        s.ShowTime = sl.ShowTime;
        s.ShowTicketInfo = sl.ShowTicket;
        s.ShowDateEntered = DateTime.Now;

        try
        {

            db.Shows.Add(s);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            result = 0;
            throw ex;
        }
        return result;
    }

    public int AddShowDetails(ShowDetailsLite sdl)
    {
        int result = 1;

   

        ShowDetail sd = new ShowDetail();


        var shk = from sk in db.ShowDetails
                  where sk.Show.ShowName.Equals(sdl.ShowName)
                  select new { sk.ShowKey };

        var ark = from ak in db.ShowDetails
                  where ak.Artist.ArtistName.Equals(sdl.ArtistNames)
                  select new { ak.ArtistKey };

        sd.ArtistKey = sdl.ArtistKey;
        sd.ShowKey = sdl.ShowKey;
        sd.ShowDetailArtistStartTime = sdl.ShowDetailArtistStartTime;
        sd.ShowDetailAdditional = sdl.ShowDetailAdditional;


        try
        {

            db.ShowDetails.Add(sd);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            result = 0;
            throw ex;
        }

        return result;

    }



    ShowTrackerEntities ste = new ShowTrackerEntities();
    public List<string> GetArtists()
    {
        var arts = from a in ste.Artists
                   orderby a.ArtistName
                   select new { a.ArtistName };


        List<string> artists = new List<string>();
        foreach (var ar in arts)
        {
            artists.Add(ar.ArtistName.ToString());//it 
        }

        return artists;//it will return all the authors
    }


    public List<string> GetVenue()
    {
        var ven = from a in ste.Venues
                  orderby a.VenueName
                  select new { a.VenueName };


        List<string> venues = new List<string>();
        foreach (var ve in ven)
        {
            venues.Add(ve.VenueName.ToString());//it 
        }

        return venues;//it will return all the authors
    }


    public List<string> GetShow()
    {
        var shs = from a in ste.Shows
                  orderby a.ShowName
                  select new { a.ShowName };


        List<string> shows = new List<string>();
        foreach (var sh in shs)
        {
            shows.Add(sh.ShowName.ToString());//it 
        }

        return shows;//it will return all the authors
    }


    public List<VenueShow> GetShowsByVenue(string venueName)
    {
        var shws = from s in ste.Shows
                   where s.Venue.VenueName.Equals(venueName)
                   select new { s.ShowName, s.ShowTime, s.ShowDate };

        List<VenueShow> venues = new List<VenueShow>();

        foreach (var a in shws)
        {
            VenueShow vlite = new VenueShow();
            vlite.Name = a.ShowName;
            vlite.Time = a.ShowTime.ToString();
            vlite.Date = a.ShowDate.ToShortDateString();

            venues.Add(vlite);

        }
        return venues;
    }

    public List<ArtistShows> GetShowsByArtist(string artistName)
    {
        var shws = from s in ste.Shows
                   from sd in s.ShowDetails
                   where sd.Artist.ArtistName.Equals(artistName)
                   select new { s.ShowName, s.ShowTime, s.ShowDate, s.Venue.VenueName };

        List<ArtistShows> ArtistShows = new List<ArtistShows>();

        foreach (var a in shws)
        {
            ArtistShows alite = new ArtistShows();
            alite.Name = a.ShowName;
            alite.Time = a.ShowTime.ToString();
            alite.Date = a.ShowDate.ToShortDateString();
            alite.Venue = a.VenueName;

            ArtistShows.Add(alite);

        }
        return ArtistShows;
    }



















}
