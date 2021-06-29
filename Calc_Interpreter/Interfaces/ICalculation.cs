namespace Calc_Interpreter
{
    public interface ICalculation
    {
        string Name { get; }
        int Priority { get; }
        decimal Argument1 { get; set; }
        decimal Argument2 { get; set; }
        decimal Result { get; set; }

        /* Radek's code
        void SetArguments(params decimal[] args);

        */
        decimal Calculate();
        
    }


    /* Radek's code
    public class Calculation : ICalculation
    {
        // protected decimal[] _args;

        public string Name => throw new System.NotImplementedException();

        public int Priority => throw new System.NotImplementedException();

        public decimal Argument1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public decimal Argument2 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        
        public decimal Calculate()
        {
            throw new System.NotImplementedException();
        }

        public void SetArguments(params decimal[] args)
        {
            _args = args;
        }
        

        
        public override string ToString()
        {
            return $"{Argument1} {Symbol} {Argument2} = {Calculate()}";
        }
        
    }
    */
}