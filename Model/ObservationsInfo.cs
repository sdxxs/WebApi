namespace apiweb.Model
{
    public class ObservationsInfo
    {
        public int Id { get; set; }
        public long chatId { get; set; }
        public string speciesCode { get; set; }
        public string comName { get; set; }
        public string sciName { get; set; }
        public string locId { get; set; }
        public string locName { get; set; }
        public string obsDt { get; set; }
        public int howMany { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public bool obsValid { get; set; }
        public bool obsReviewed { get; set; }
        public bool locationPrivate { get; set; }
        public string subId { get; set; }
        public ObservationsInfo(long chatId, string sciName, string locName, string obsDt, int howMany)
        {
            this.chatId = chatId;
            this.sciName = sciName;
            this.locName = locName;
            this.obsDt = obsDt;
            this.howMany = howMany;

            speciesCode = " ";
            comName = " ";
            locId = " ";
            lat = 0;
            lng = 0;
            obsValid = false;
            obsReviewed = false;
            locationPrivate = false;
            subId = " ";
        }
    }
}