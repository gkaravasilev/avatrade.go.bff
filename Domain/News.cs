namespace AvaTrade.Go.BFF.Domain
{
    public class News
    {
        public string Id { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Instrument Instrument { get; set; }

        public double MinutesToRead
        {
            get
            {
                var result = (double)this.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length / 250;

                return Math.Ceiling(result);
            }
        }

        public int DaysFromToday()
        {
            return (int)(DateTime.UtcNow - Date).TotalDays;
        }
    }
}
