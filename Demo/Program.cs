using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Singleton s3 = Singleton.Instance;
            if (s1 == s2)
            {
                s1.Message();
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }
            if (s1 == s3)
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }
            if (s2 == s3)
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }
            Console.ReadKey();
        }
    }
    #region No Thread Safe Singleton
    //public sealed class Singleton
    //{
    //    private static Singleton _instance=null;
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new Singleton();
    //            }
    //            return _instance;
    //        }
    //    }
    //    private Singleton()
    //    {

    //    }
    //    public void Message()
    //    {
    //        Console.WriteLine("This is singleton class method.");
    //    }
    //}
    #endregion


    #region Thread Safety Singleton
    //public sealed class Singleton
    //{
    //    private static readonly object @lock= new object();
    //    private static Singleton _instance = null;
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            lock (@lock)
    //            {
    //                if (_instance == null)
    //                {
    //                    _instance = new Singleton();
    //                }
    //            }
    //            return _instance;
    //        }
    //    }
    //    private Singleton()
    //    {

    //    }
    //    public void Message()
    //    {
    //        Console.WriteLine("This is singleton class method.");
    //    }
    //} 
    #endregion

    #region Thread Safety Singleton using Double Check Locking
    //public sealed class Singleton
    //{
    //    private static readonly object @lock = new object();
    //    private static Singleton _instance = null;
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                lock (@lock)
    //                {
    //                    if (_instance == null)
    //                    {
    //                        _instance = new Singleton();
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }
    //    private Singleton()
    //    {

    //    }
    //    public void Message()
    //    {
    //        Console.WriteLine("This is singleton class method.");
    //    }
    //} 
    #endregion

    #region Thread Safe Singleton without using locks and no lazy instantiation
    //public sealed class Singleton
    //{
    //    private static readonly Singleton _instance = new Singleton();
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            return _instance;
    //        }
    //    }

    //    static Singleton()
    //    {

    //    }
    //    private Singleton()
    //    {

    //    }
    //    public void Message()
    //    {
    //        Console.WriteLine("This is singleton class method.");
    //    }
    //} 
    #endregion

    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance => _instance.Value;
        private Singleton() { }
        public void Message()
        {
            Console.WriteLine("This is singleton class method.");
        }
    }
}
