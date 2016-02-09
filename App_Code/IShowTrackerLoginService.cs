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
