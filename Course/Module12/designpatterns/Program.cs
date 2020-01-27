using designpatterns.Behavioral;
using designpatterns.Creational;
using designpatterns.Structural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creational
            #region Abstract Factory Design Pattern.
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
            #endregion

            #region  Builder Design Pattern.
            //VehicleBuilder builder;
            //// Create shop with vehicle builders
            //Shop shop = new Shop();

            //// Construct and display vehicles
            //builder = new ScooterBuilder();
            //shop.Construct(builder);
            //builder.Vehicle.Show();

            //builder = new CarBuilder();
            //shop.Construct(builder);
            //builder.Vehicle.Show();

            //builder = new MotorCycleBuilder();
            //shop.Construct(builder);
            //builder.Vehicle.Show();
            #endregion

            #region Factory Method Design Pattern.
            //Document[] documents = new Document[2];

            //documents[0] = new Resume();
            //documents[1] = new Report();

            //// Display document pages

            //foreach (Document document in documents)
            //{
            //    Console.WriteLine("\n" + document.GetType().Name + "--");
            //    foreach (Page page in document.Pages)
            //    {
            //        Console.WriteLine(" " + page.GetType().Name);
            //    }
            //}
            #endregion

            #region Prototype Design Pattern
            //ColorManager colormanager = new ColorManager();
            //// Initialize with standard colors

            //colormanager["red"] = new Color(255, 0, 0);
            //colormanager["green"] = new Color(0, 255, 0);
            //colormanager["blue"] = new Color(0, 0, 255);

            //// User adds personalized colors

            //colormanager["angry"] = new Color(255, 54, 0);
            //colormanager["peace"] = new Color(128, 211, 128);
            //colormanager["flame"] = new Color(211, 34, 20);

            //// User clones selected colors

            //Color color1 = colormanager["red"].Clone() as Color;
            //Color color2 = colormanager["peace"].Clone() as Color;
            //Color color3 = colormanager["flame"].Clone() as Color;
            #endregion

            #region Singletone
            //LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            //LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            //LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            //LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            //// Same instance?

            //if (b1 == b2 && b2 == b3 && b3 == b4)
            //{
            //    Console.WriteLine("Same instance\n");
            //}

            //// Load balance 15 server requests

            //LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            //for (int i = 0; i < 15; i++)
            //{
            //    string server = balancer.Server;
            //    Console.WriteLine("Dispatch Request to: " + server);
            //}
            #endregion
            #endregion

            #region Structural
            #region Adapter
            //// Non - adapted chemical compound
            //Compound unknown = new Compound("Unknown");
            //unknown.Display();

            //// Adapted chemical compounds
            //Compound water = new RichCompound("Water");
            //water.Display();

            //Compound benzene = new RichCompound("Benzene");
            //benzene.Display();

            //Compound ethanol = new RichCompound("Ethanol");
            //ethanol.Display();
            #endregion

            #region Bridge
            //// Create RefinedAbstraction
            //Customers customers = new Customers("Chicago");

            //// Set ConcreteImplementor
            //customers.Data = new CustomersData();

            //// Exercise the bridge
            //customers.Show();
            //customers.Next();
            //customers.Show();
            //customers.Next();
            //customers.Show();
            //customers.Add("Henry Velasquez");

            //customers.ShowAll();
            #endregion

            #region Composite
            //// Create a tree structure 
            //CompositeElement root = new CompositeElement("Picture");
            //root.Add(new PrimitiveElement("Red Line"));
            //root.Add(new PrimitiveElement("Blue Circle"));
            //root.Add(new PrimitiveElement("Green Box"));

            //// Create a branch
            //CompositeElement comp = new CompositeElement("Two Circles");
            //comp.Add(new PrimitiveElement("Black Circle"));
            //comp.Add(new PrimitiveElement("White Circle"));
            //root.Add(comp);

            //// Add and remove a PrimitiveElement
            //PrimitiveElement pe = new PrimitiveElement("Yellow Line");
            //root.Add(pe);
            //root.Remove(pe);

            //// Recursively display nodes
            //root.Display(1);
            #endregion

            #region Decorator
            //// Create book
            //Book book = new Book("Worley", "Inside ASP.NET", 10);
            //book.Display();

            //// Create video
            //Video video = new Video("Spielberg", "Jaws", 23, 92);
            //video.Display();

            //// Make video borrowable, then borrow and display
            //Console.WriteLine("\nMaking video borrowable:");

            //Borrowable borrowvideo = new Borrowable(video);
            //borrowvideo.BorrowItem("Customer #1");
            //borrowvideo.BorrowItem("Customer #2");

            //borrowvideo.Display();
            #endregion

            #region Facade
            //// Facade
            //Mortgage mortgage = new Mortgage();
            //// Evaluate mortgage eligibility for customer
            //Customer customer = new Customer("Ann McKinsey");
            //bool eligible = mortgage.IsEligible(customer, 125000);
            //Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));
            #endregion

            #region Flyweight
            //// Build a document with text
            //string document = "AAZZBBZB";
            //char[] chars = document.ToCharArray();

            //CharacterFactory factory = new CharacterFactory();

            //// extrinsic state
            //int pointSize = 10;

            //// For each character use a flyweight object
            //foreach (char c in chars)
            //{
            //    pointSize++;
            //    Character character = factory.GetCharacter(c);
            //    character.Display(pointSize);
            //}
            #endregion

            #region Proxy
            //// Create math proxy
            //MathProxy proxy = new MathProxy();

            //// Do the math
            //Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            //Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            //Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            //Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
            #endregion
            #endregion

            #region Behavioral
            #region Chain of Responsibility
            //// Setup Chain of Responsibility
            //Approver larry = new Director();
            //Approver sam = new VicePresident();
            //Approver tammy = new President();

            //larry.SetSuccessor(sam);
            //sam.SetSuccessor(tammy);

            //// Generate and process purchase requests

            //Purchase p = new Purchase(2034, 350.00, "Assets");
            //larry.ProcessRequest(p);

            //p = new Purchase(2035, 32590.10, "Project X");
            //larry.ProcessRequest(p);

            //p = new Purchase(2036, 122100.00, "Project Y");
            //larry.ProcessRequest(p);
            #endregion

            #region Command
            ////// Create user and let her compute
            //User user = new User();

            //// User presses calculator buttons
            //user.Compute('+', 100);
            //user.Compute('-', 50);
            //user.Compute('*', 10);
            //user.Compute('/', 2);

            //// Undo 4 commands
            //user.Undo(4);

            //// Redo 3 commands
            //user.Redo(3);
            #endregion

            #region Interpreter 
            //string roman = "MCMXXVIII";
            //Context context = new Context(roman);

            //// Build the 'parse tree'

            //List<Expression> tree = new List<Expression>();
            //tree.Add(new ThousandExpression());
            //tree.Add(new HundredExpression());
            //tree.Add(new TenExpression());
            //tree.Add(new OneExpression());

            //// Interpret
            //foreach (Expression exp in tree)
            //{
            //    exp.Interpret(context);
            //}

            //Console.WriteLine("{0} = {1}", roman, context.Output);
            #endregion

            #region Iterator
            //// Build a collection
            //Collection collection = new Collection();
            //collection[0] = new Item("Item 0");
            //collection[1] = new Item("Item 1");
            //collection[2] = new Item("Item 2");
            //collection[3] = new Item("Item 3");
            //collection[4] = new Item("Item 4");
            //collection[5] = new Item("Item 5");
            //collection[6] = new Item("Item 6");
            //collection[7] = new Item("Item 7");
            //collection[8] = new Item("Item 8");

            //// Create iterator
            //Iterator iterator = collection.CreateIterator();

            //// Skip every other item
            //iterator.Step = 2;

            //Console.WriteLine("Iterating over collection:");

            //for (Item item = iterator.First();
            //    !iterator.IsDone; item = iterator.Next())
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region Mediator
            //// Create chatroom
            //Chatroom chatroom = new Chatroom();

            //// Create participants and register them
            //Participant George = new Beatle("George");
            //Participant Paul = new Beatle("Paul");
            //Participant Ringo = new Beatle("Ringo");
            //Participant John = new Beatle("John");
            //Participant Yoko = new NonBeatle("Yoko");

            //chatroom.Register(George);
            //chatroom.Register(Paul);
            //chatroom.Register(Ringo);
            //chatroom.Register(John);
            //chatroom.Register(Yoko);

            //// Chatting participants

            //Yoko.Send("John", "Hi John!");
            //Paul.Send("Ringo", "All you need is love");
            //Ringo.Send("George", "My sweet Lord");
            //Paul.Send("John", "Can't buy me love");
            //John.Send("Yoko", "My sweet love");
            #endregion

            #region Memento
            //SalesProspect s = new SalesProspect();
            //s.Name = "Noel van Halen";
            //s.Phone = "(412) 256-0990";
            //s.Budget = 25000.0;

            //// Store internal state

            //ProspectMemory m = new ProspectMemory();
            //m.Memento = s.SaveMemento();

            //// Continue changing originator

            //s.Name = "Leo Welch";
            //s.Phone = "(310) 209-7111";
            //s.Budget = 1000000.0;

            //// Restore saved state
            //s.RestoreMemento(m.Memento);
            #endregion

            #region Observer
            //// Create IBM stock and attach investors
            //IBM ibm = new IBM("IBM", 120.00);
            //ibm.Attach(new Investor("Sorros"));
            //ibm.Attach(new Investor("Berkshire"));

            //// Fluctuating prices will notify investors
            //ibm.Price = 120.10;
            //ibm.Price = 121.00;
            //ibm.Price = 120.50;
            //ibm.Price = 120.75;
            #endregion

            #region State
            //// Open a new account
            //Account account = new Account("Jim Johnson");
            //// Apply financial transactions

            //account.Deposit(500.0);
            //account.Deposit(300.0);
            //account.Deposit(550.0);
            //account.PayInterest();
            //account.Withdraw(2000.00);
            //account.Withdraw(1100.00);
            #endregion

            #region Strategy
            //// Two contexts following different strategies
            //SortedList studentRecords = new SortedList();

            //studentRecords.Add("Samual");
            //studentRecords.Add("Jimmy");
            //studentRecords.Add("Sandra");
            //studentRecords.Add("Vivek");
            //studentRecords.Add("Anna");

            //studentRecords.SetSortStrategy(new QuickSort());
            //studentRecords.Sort();

            //studentRecords.SetSortStrategy(new ShellSort());
            //studentRecords.Sort();

            //studentRecords.SetSortStrategy(new MergeSort());
            //studentRecords.Sort();
            #endregion

            #region Template
            //DataAccessObject daoCategories = new Categories();
            //daoCategories.Run();

            //DataAccessObject daoProducts = new Products();
            //daoProducts.Run();
            #endregion

            #region Visitor
            //// Setup employee collection
            //Employees e = new Employees();
            //e.Attach(new Clerk());
            //e.Attach(new Manager());
            //e.Attach(new ExecuterDirector());

            //// Employees are 'visited'
            //e.Accept(new IncomeVisitor());
            //e.Accept(new VacationVisitor());
            #endregion
            #endregion


            #region UnityOfWork
            /*
            public class HomeController : Controller
            {
                UnitOfWork unitOfWork;
                public HomeController()
                {
                    unitOfWork = new UnitOfWork();
                }
                public ActionResult Index()
                {
                    var books = unitOfWork.Books.GetAll();
                    return View();
                }
 
                public ActionResult Create()
                {
                    return View();
                }
 
                [HttpPost]
                public ActionResult Create(Book b)
                {
                    if(ModelState.IsValid)
                    {
                        unitOfWork.Books.Create(b);
                        unitOfWork.Save();
                        return RedirectToAction("Index");
                    }
                    return View(b);
                }
 
                public ActionResult Edit(int id)
                {
                    Book b = unitOfWork.Books.Get(id);
                    if (b == null)
                        return HttpNotFound();
                    return View(b);
                }
 
                [HttpPost]
                public ActionResult Edit(Book b)
                {
                    if (ModelState.IsValid)
                    {
                        unitOfWork.Books.Update(b);
                        unitOfWork.Save();
                        return RedirectToAction("Index");
                    }
                    return View(b);
                }
 
                public ActionResult Delete(int id)
                {
                    unitOfWork.Books.Delete(id);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
 
                protected override void Dispose(bool disposing)
                {
                    unitOfWork.Dispose();
                    base.Dispose(disposing);
                }
            }
             */
            #endregion
            Console.ReadKey();
        }
    }
}
