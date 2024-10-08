using EpicChain.SmartContract.Framework;
using EpicChain.SmartContract.Framework.Services.EpicChain;
using System;
using System.Numerics;

namespace Serialization
{
    public class Contract1 : SmartContract
    {
        public static object Main(string operation, object[] args)
        {
            if (operation == "serialize")
            {
                var news = new News() { Title = "Hello", Content = "World", BlockHeight = Blockchain.GetHeight() };
                var s = news.Serialize();
                var d = s.Deserialize() as News;

                //return $"{d.BlockHeight} {d.Title} {d.Content}"; 这么写会报错
                //return d.BlockHeight + d.Title + d.Content; 这么写会报错
                //return d.BlockHeight.ToString(); 这么写会报错，抓狂

                return d.BlockHeight;
            }
            return true;
        }
    }
}
