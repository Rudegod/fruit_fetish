using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fruit_fetish
{
    internal class Program
    {
        public class Fruit
        {
            private string name, code;
            private int price;
            
            public Fruit(string name, string code, int price)
            {
                this.name = name;
                this.code = code;
                this.price = price;
            }
            public void Print()
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"name: {this.name}");
                Console.WriteLine($"code: {this.code}");
                Console.WriteLine($"price: {this.price}");
            }
            public string getName()
            {
                return this.name;
            }
            public string getCode()
            {
                return this.code;
            }
            public int getPrice()
            {
                return this.price;
            }
            public void changeName(string name)
            {
                this.name = name;
            }
            public void changePrice(int price)
            {
                this.price = price;
            }
        }
        public class TareBar
        {
            private Dictionary<string, string> sellerIdPass = new Dictionary<string, string>();
            private Dictionary<string, string> costumerIdPass = new Dictionary<string, string>();
            private List<Fruit> fruitList = new List<Fruit>();


            public TareBar()
            {
                sellerIdPass.Add("yaz", "12345678");
                loginPage();
            }
            public void printFruitList()
            {
                foreach(Fruit fruit in fruitList)
                {
                    fruit.Print();
                }
            }
            public bool checkExistFruitCode(string code)
            {
                foreach(Fruit fruit in fruitList)
                {
                    if(fruit.getCode() == code)
                        return true;
                }
                return false;
            }
            public bool checkExistFruitName(string name)
            {
                foreach (Fruit fruit in fruitList)
                {
                    if (fruit.getName() == name)
                        return true;
                }
                return false;
            }
            public void sellerPage()
            {
                string options, edit, code, name, temp;
                int price;
                while(true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("options:");
                        Console.WriteLine("1. show fruit list");
                        Console.WriteLine("2. edit");
                        Console.WriteLine("3. return to login page");
                        Console.WriteLine("4. close app");
                        Console.Write("------->");
                        options = Console.ReadLine();
                        Console.Clear();
                        if (options == "1")
                        {
                            printFruitList();
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("enter for return to options");
                            Console.ReadLine();
                        }
                        else if (options == "2")
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("edit options:");
                                    Console.WriteLine("1. add a fruit");
                                    Console.WriteLine("2. remove a fruit");
                                    Console.WriteLine("3. edit name and price");
                                    Console.WriteLine("4. return to home");
                                    Console.Write("------->");
                                    edit = Console.ReadLine();
                                    if (edit == "1")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.Clear();
                                                Console.WriteLine("enter a name (write esc for exit)");
                                                Console.Write("------->");
                                                name = Console.ReadLine();
                                                if(name == "esc")
                                                    break;
                                                Console.WriteLine("enter a code (can't change)");
                                                Console.Write("------->");
                                                code = Console.ReadLine();
                                                Console.WriteLine("enter price");
                                                Console.Write("------->");
                                                price = Convert.ToInt32(Console.ReadLine());
                                                if (!checkExistFruitCode(code) && !checkExistFruitName(name))
                                                {
                                                    Fruit fruit = new Fruit(name, code, price);
                                                    fruitList.Add(fruit);
                                                    Console.WriteLine("new fruit added");
                                                    Thread.Sleep(1000);
                                                    break;
                                                }
                                                else
                                                    Console.WriteLine("code or name is already exist!!");
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                            }
                                        }
                                    }
                                    else if (edit == "2")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("enter code of fruit that you want to remove (write esc for exit)");
                                                Console.Write("------->");
                                                code = Console.ReadLine();
                                                if(code == "esc")
                                                    break ;
                                                if (checkExistFruitCode(code))
                                                {
                                                    foreach (Fruit fruit in fruitList)
                                                    {
                                                        if (fruit.getCode() == code)
                                                        {
                                                            fruitList.Remove(fruit);
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("remove succesfully");
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                }
                                                else
                                                    Console.WriteLine("this code is not exist!!!");
                                            }
                                            catch(Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                            }
                                        }

                                    }
                                    else if (edit == "3")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.Clear();
                                                Console.WriteLine("enter code of fruit that you want edit (write esc for exit)");
                                                Console.Write("------->");
                                                code = Console.ReadLine();
                                                if(code == "esc")
                                                    break;
                                                if (checkExistFruitCode(code))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("enter 1 for edit name and 2 for edit price");
                                                    Console.Write("------->");
                                                    temp = Console.ReadLine();
                                                    if (temp == "1")
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("enter new name (write esc for exit)");
                                                                Console.Write("------->");
                                                                name = Console.ReadLine();
                                                                if (name == "esc")
                                                                    break;
                                                                if (!existCheckCostumerId(name))
                                                                {
                                                                    foreach (Fruit fruit in fruitList)
                                                                    {
                                                                        if (fruit.getCode() == code)
                                                                        {
                                                                            fruit.changeName(name);
                                                                            Console.WriteLine("change name succesfully");
                                                                            Thread.Sleep(1000);
                                                                            break;
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("this name is already exist");
                                                                    Thread.Sleep(1000);
                                                                }
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Console.WriteLine($"{e.Message}");
                                                                Thread.Sleep(1000);
                                                            }
                                                        }
                                                    }
                                                    else if (temp == "2")
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("enter new price (write -1 for exit)");
                                                                price = Convert.ToInt32(Console.ReadLine());
                                                                if (price == -1)
                                                                    break;
                                                                if (price > 0)
                                                                {
                                                                    foreach (Fruit fruit in fruitList)
                                                                    {
                                                                        if (fruit.getCode() == code)
                                                                        {
                                                                            fruit.changePrice(price);
                                                                            Console.WriteLine("change price succesfully");
                                                                            Thread.Sleep(1000);
                                                                            break;
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("price cant be negative and zero");
                                                                    Thread.Sleep(1000);
                                                                }
                                                            }
                                                            catch(Exception e)
                                                            {
                                                                Console.WriteLine($"{e.Message}");
                                                                Thread.Sleep(1000);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("wrong chois!!!");
                                                        Thread.Sleep(1000);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("this code isnt exist");
                                                    Thread.Sleep(1000);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                                Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                    else if (edit == "4")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("wrong chois!!!");
                                        Thread.Sleep(700);
                                        Console.Clear();
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"{e.Message}");
                                    Thread.Sleep(1000);
                                }

                            }
                        }
                        else if (options == "3")
                        {
                            loginPage();
                            return;
                        }
                        else if(options == "4")
                            return;
                        else
                        {
                            Console.WriteLine("wrong chois!!!");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }

            }
            public void costumerPage()
            {
                string options, code, temp;
                int weight;
                int finalPrice;
                bool f;
                Dictionary<Fruit, int> shoppingCart = new Dictionary<Fruit, int>();
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("optrions:");
                        Console.WriteLine("1. show fruit list");
                        Console.WriteLine("2. shopping cart");
                        Console.WriteLine("3. return to login page");
                        Console.WriteLine("4. exit app");
                        Console.Write("------->");
                        options = Console.ReadLine();
                        if(options == "1")
                        {
                            printFruitList();
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("enter for return to options");
                            Console.ReadLine();
                        }
                        else if(options == "2")
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("optrions:");
                                    Console.WriteLine("1. add");
                                    Console.WriteLine("2. remove");
                                    Console.WriteLine("3. edit");
                                    Console.WriteLine("4. purchase");
                                    Console.WriteLine("5. return to home page");
                                    Console.Write("------->");
                                    options = Console.ReadLine();
                                    if( options == "1")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.Clear();
                                                Console.WriteLine("enter code of fruit that you want buy");
                                                Console.Write("------->");
                                                code = Console.ReadLine();
                                                if (checkExistFruitCode(code))
                                                {
                                                    foreach (Fruit fruit in fruitList)
                                                    {
                                                        if (fruit.getCode() == code)
                                                        {
                                                            Console.WriteLine("enter weight");
                                                            Console.Write("------->");
                                                            weight = Convert.ToInt32(Console.ReadLine());
                                                            shoppingCart.Add(fruit, weight);
                                                            if (shoppingCart.ContainsKey(fruit))
                                                                Console.WriteLine("add succesfull");
                                                            else
                                                                Console.WriteLine("kir shodi");
                                                            Thread.Sleep(1000);
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("this code is not exist!!!");
                                                    Thread.Sleep(1000);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        }
                                    }
                                    else if( options == "2")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                f = false;
                                                Console.Clear();
                                                Console.WriteLine("enter code of fruit that you want remove (write esc for exit)");
                                                Console.Write("------->");
                                                code = Console.ReadLine();
                                                if(code == "esc")
                                                    break;
                                                foreach(KeyValuePair<Fruit, int> kvp in shoppingCart)
                                                {
                                                    if (kvp.Key.getCode() == code)
                                                    {
                                                        f = true;
                                                        shoppingCart.Remove(kvp.Key);
                                                        break;
                                                    }
                                                }
                                                if (f)
                                                {
                                                    Console.WriteLine("remove succesful");
                                                    Thread.Sleep(1000);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("this code isnt exist!!!");
                                                    Thread.Sleep(1000);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                                Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                    else if(options == "3")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                f = false;
                                                Console.Clear();
                                                Console.WriteLine("enter code of fruit that you want edit (write esc for exit)");
                                                Console.Write("------->");
                                                code = Console.ReadLine();
                                                if(code == "esc")
                                                {
                                                    break;
                                                }
                                                foreach (KeyValuePair<Fruit, int> kvp in shoppingCart)
                                                {
                                                    if (kvp.Key.getCode() == code)
                                                    {
                                                        f = true;
                                                        Console.WriteLine("enter new weight");
                                                        Console.Write("------->");
                                                        weight = Convert.ToInt32(Console.ReadLine());
                                                        shoppingCart[kvp.Key] = weight;
                                                        break;
                                                    }
                                                }
                                                if (f)
                                                {
                                                    Console.WriteLine("edit succesful");
                                                    Thread.Sleep(1000);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("this code isnt exist!!!");
                                                    Thread.Sleep(1000);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                                Thread.Sleep(1000);
                                                break;
                                            }
                                        }
                                    }
                                    else if (options == "4")
                                    {
                                        while (true)
                                        {
                                            try
                                            {
                                                finalPrice = 0;
                                                Console.Clear();
                                                foreach (KeyValuePair<Fruit, int> kvp in shoppingCart)
                                                {
                                                    finalPrice += (kvp.Value * kvp.Key.getPrice());
                                                    kvp.Key.Print();
                                                    Console.WriteLine($"weight: {kvp.Value}");
                                                    Console.WriteLine("----------------------------------");
                                                }
                                                Console.WriteLine($"final price: {finalPrice}");
                                                Console.WriteLine("enter 1 to payment and 2 for exit");
                                                Console.Write("------->");
                                                temp = Console.ReadLine();
                                                if(temp == "1")
                                                {
                                                    shoppingCart.Clear();
                                                    Console.WriteLine("payment done!!");
                                                    Thread.Sleep(1000);
                                                    break;
                                                }
                                                else if(temp == "2")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("wrong chois!!!");
                                                    Thread.Sleep(1000);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine($"{e.Message}");
                                                Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                    else if(options == "5")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("wrong chois");
                                        Thread.Sleep(1000);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"{e.Message}");
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                        else if(options == "3")
                        {
                            loginPage();
                            return;
                        }
                        else if(options == "4")
                        {
                            return;
                        }
                        else
                        {

                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                        Thread.Sleep(1000);
                    }
                }
            }
            public bool existCheckSellerId(string id)
            {
                foreach(KeyValuePair<string, string> kvp in sellerIdPass)
                {
                    if (kvp.Key == id)
                        return true;
                }
                return false;
            }
           public bool existCheckCostumerId(string id)
            {
                foreach (KeyValuePair<string, string> kvp in costumerIdPass)
                {
                    if (kvp.Key == id)
                        return true;
                }
                return false;
            }
            public bool checkPass(string pass)
            {

                if (pass.Length < 8)
                {
                    Console.WriteLine("least 8 letter!!!");
                    Thread.Sleep(1000);
                    return false;
                }
                return true;
            }
            public void loginPage()
            {
                string id, pass;
                int sellerOrCostumer;
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("enter 1 for login as a seller, 2 as a costumer and 3 for exit");
                        sellerOrCostumer = Convert.ToInt32(Console.ReadLine());
                        if (sellerOrCostumer == 1 || sellerOrCostumer == 2)
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("enter 0 for register, 1 for login and 2 for return");
                                    id = Console.ReadLine();
                                    if (id == "0" || id == "1")
                                    {
                                        if (id == "0") //sign up
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("enter an id (least 3 letter)");
                                                    Console.Write("------->");
                                                    id = Console.ReadLine();
                                                    Console.WriteLine("enter a password (8 letter)");
                                                    Console.Write("------->");
                                                    pass = Console.ReadLine();
                                                    if (!existCheckCostumerId(id) && !existCheckSellerId(id) && checkPass(pass))
                                                    {
                                                        if (sellerOrCostumer == 1)
                                                        {
                                                            sellerIdPass.Add(id, pass);
                                                            Console.WriteLine("sign up succesful");
                                                            Thread.Sleep(1000);
                                                            Console.Clear();
                                                            sellerPage();
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            costumerIdPass.Add(id, pass);
                                                            Console.WriteLine("sign up succesful");
                                                            Thread.Sleep(1000);
                                                            Console.Clear();
                                                            costumerPage();
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("id or password is wrong!!!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine($"{e.Message}");
                                                }
                                            }
                                        }
                                        else       //sign in
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("enter your id");
                                                    Console.Write("------->");
                                                    id = Console.ReadLine();
                                                    Console.WriteLine("enter your password");
                                                    Console.Write("------->");
                                                    pass = Console.ReadLine();
                                                    if (sellerOrCostumer == 1)
                                                    {
                                                        foreach (KeyValuePair<string, string> kvp in sellerIdPass)
                                                        {
                                                            if (kvp.Key == id && kvp.Value == pass)
                                                            {
                                                                Console.WriteLine("login succesfull!!  welcom");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                sellerPage();
                                                                return;
                                                            }
                                                        }
                                                        Console.WriteLine("somthing is wrong!!!");
                                                        Thread.Sleep(500);
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        foreach (KeyValuePair<string, string> kvp in costumerIdPass)
                                                        {
                                                            if (kvp.Key == id && kvp.Value == pass)
                                                            {
                                                                Console.WriteLine("login succesfull!!  welcom");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                costumerPage();
                                                                return;
                                                            }
                                                        }
                                                        Console.WriteLine("somthing is wrong!!!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine($"{e.Message}");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();
                                                }
                                            }

                                        }
                                    }
                                    else if(id == "2")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("wrong chois!!!");
                                        Console.Clear();
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"{e.Message}");
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                        else if (sellerOrCostumer == 3)
                            return;
                        else
                        {
                            Console.WriteLine("wrong chois!!!");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            TareBar tarebar = new TareBar();
        }
    }
}
