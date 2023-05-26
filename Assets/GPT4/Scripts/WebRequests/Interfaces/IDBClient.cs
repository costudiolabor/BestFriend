using Cysharp.Threading.Tasks;
using Enums;

public  interface IDBClient {
    public HttpStatus responseCode{ get;  set; }

    public string authorKey{ get; set; }
}
