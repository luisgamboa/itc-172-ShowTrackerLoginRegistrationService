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
    int AddShow(NewShow ns);

    [OperationContract]
    int AddArtist(NewArtist aa);


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

[DataContract]
public class NewShow
{
    [DataMember]
    public string ShowKey { set; get; }

    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string VenueKey { set; get; }

    [DataMember]
    public string ShowDate { set; get; }

    [DataMember]
    public string ShowTime { set; get; }

    [DataMember]
    public string ShowTicketInfo { set; get; }

    [DataMember]
    public string ShowDateEntered { set; get; }

    [DataMember]
    public List<string> Shows
    { set; get; }

    [DataMember]
    public string ArtistKey { set; get; }

    [DataMember]
    public string ShowDetailAdditional { set; get; }
    [DataMember]
    public List<string> Artists
    { set; get; }



}

[DataContract]
public class NewArtist {

    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public string ArtistEmail { set; get; }

}

