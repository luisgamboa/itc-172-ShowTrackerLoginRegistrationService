using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShowTrackerLoginService" in both code and config file together.
[ServiceContract]
public interface IShowTrackerLoginService
{
    [OperationContract]
    int VenueLogin(string password, string username);

    [OperationContract]
    int VenueRegistration(VenueLite r);

    [OperationContract]
    int AddShow(ShowLite sl);

    [OperationContract]
    int AddArtist(ArtistLite al);

    [OperationContract]
    int AddShowDetails(ShowDetailsLite sdl);

    [OperationContract]
    int FanLogin(string password, string username);

    [OperationContract]
    int FanRegistration(FanLite r);



    [OperationContract]
    List<string> GetArtists();

    [OperationContract]
    List<string> GetVenue();

    [OperationContract]
    List<string> GetShow();

    [OperationContract]
    List<VenueShow> GetShowsByVenue(string venueName);

    [OperationContract]
    List<ArtistShows> GetShowsByArtist(string artistName);


}

[DataContract]
public class VenueLite
{
    [DataMember]
    public string VenueName { set; get; }

    [DataMember]
    public string VenueAddress { set; get; }

    [DataMember]
    public string VenueCity { set; get; }

    [DataMember]
    public string VenueState { set; get; }

    [DataMember]
    public string VenueZipCode { set; get; }

    [DataMember]
    public string VenuePhone { set; get; }

    [DataMember]
    public string VenueEmail { set; get; }

    [DataMember]
    public string VenueWebPage { set; get; }

    [DataMember]
    public int VenueAgeRestriction { set; get; }

    [DataMember]
    public string VenueLoginUserName { set; get; }

    [DataMember]
    public string VenueLoginPasswordPlain { set; get; }


}



public class FanLite
{
    [DataMember]
    public string FanName { set; get; }

    [DataMember]
    public string FanEmail { set; get; }

    [DataMember]
    public string FanLoginUserName { set; get; }

    [DataMember]
    public string FanLoginPasswordPlain { set; get; }



}



[DataContract]
public class ShowLite
{
    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public DateTime ShowDate { set; get; }

    [DataMember]
    public TimeSpan ShowTime { set; get; }

    [DataMember]
    public string ShowTicket { set; get; }

    [DataMember]
    public int VenueKey { set; get; }

}

[DataContract]
public class ShowDetailsLite
{
    
    [DataMember]
    public List<string> ArtistNames
    { set; get; }

    [DataMember]
    public int ArtistKey { set; get; }

    [DataMember]
    public TimeSpan ShowDetailArtistStartTime { set; get; }

    [DataMember]
    public string ShowDetailAdditional { set; get; }

    [DataMember]
    public int ShowKey { set; get; }

    [DataMember]
    public string ShowName { set; get; }

}



[DataContract]
public class ArtistLite
{
    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public string ArtistEmail { set; get; }

    [DataMember]
    public string ArtistWebPage { set; get; }


}

[DataContract]
public class VenueShow
{
    [DataMember]
    public string Name { set; get; }

    [DataMember]
    public string Date { set; get; }

    [DataMember]
    public string Time { set; get; }

}

[DataContract]
public class ArtistShows
{
    [DataMember]
    public string Name { set; get; }

    [DataMember]
    public string Date { set; get; }

    [DataMember]
    public string Time { set; get; }

    [DataMember]
    public string Venue { set; get; }

}

