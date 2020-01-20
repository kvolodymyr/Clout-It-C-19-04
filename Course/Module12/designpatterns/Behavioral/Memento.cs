using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpatterns.Behavioral
{
    /// <summary>

    /// The 'Originator' class

    /// </summary>

    class SalesProspect

    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name

        public string Name
        {
            get { return _name; }
            set

            {
                _name = value;
                Console.WriteLine("Name:  " + _name);
            }
        }

        // Gets or sets phone

        public string Phone
        {
            get { return _phone; }
            set

            {
                _phone = value;
                Console.WriteLine("Phone: " + _phone);
            }
        }

        // Gets or sets budget

        public double Budget
        {
            get { return _budget; }
            set

            {
                _budget = value;
                Console.WriteLine("Budget: " + _budget);
            }
        }

        // Stores memento

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(_name, _phone, _budget);
        }

        // Restores memento

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    /// <summary>

    /// The 'Memento' class

    /// </summary>

    class Memento

    {
        private string _name;
        private string _phone;
        private double _budget;

        // Constructor

        public Memento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }

        // Gets or sets name

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget

        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
    }

    /// <summary>

    /// The 'Caretaker' class

    /// </summary>

    class ProspectMemory

    {
        private Memento _memento;

        // Property

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
