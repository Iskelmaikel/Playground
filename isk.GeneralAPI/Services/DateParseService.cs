namespace isk.GeneralAPI.Services
{
    public class DateParseService
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
            var datetime = DateTime.Parse(dateTimeAsString);
            return datetime.Year;
        }
        public int GetYearFromSplit(string dateTimeAsString)
        {
            var splitOnHyphen = dateTimeAsString.Split('-');
            return int.Parse(splitOnHyphen[0]);
        }
    }
}
