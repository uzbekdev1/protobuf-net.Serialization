using ProtoBuf;
using ProtoBuf.Grpc.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [ProtoContract]
    public class Foo
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public double Value { get; set; }

        [ProtoMember(4)]
        public string Description { get; set; }
    }

    [Service]
    public interface IMyService
    {
        ValueTask<Foo> GetAsync();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var proto = Serializer.GetProto<Foo>(ProtoBuf.Meta.ProtoSyntax.Proto3);
            File.WriteAllText("foo.proto", proto);

            Console.WriteLine(proto);
        }
    }
}
