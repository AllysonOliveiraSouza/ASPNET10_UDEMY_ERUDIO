namespace ProjetoPrincipal.Data.Converter.Contract
{
    public interface IParser<Origin,Destiny>
    {
        Destiny Parse(Origin origin);
        List<Destiny> ParseList(List<Origin> origin);
    }
}
