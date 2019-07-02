namespace Ctf.Areas.Intro{
    public class IndexViewModel{
        public IndexViewModel(string flag)
        {
            Flag = flag;
        }
        public string Flag { get; set; }
    }
}