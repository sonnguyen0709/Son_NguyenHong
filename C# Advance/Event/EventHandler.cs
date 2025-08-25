using System;

namespace Components
{
    // Publisher: Simulates a button with a click event
    public class Button
    {
        // Standard event using EventHandler (no extra data)
        public event EventHandler Click;

        // Method to simulate a click
        public void SimulateClick()
        {
            Console.WriteLine("Button was clicked.");
            OnClick();
        }

        // Protected method to raise the event
        protected virtual void OnClick()
        {
            // Invoke the event only if there are subscribers
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    // Subscriber: Represents a form that reacts to the button click
    public class Form
    {
        private string _formName;
        public Form(string name)
        {
            _formName = name;
        }

        // Event handler method for the Click event
        public void OnButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine($"Form '{_formName}' handled the button click.");
        }
    }
}
