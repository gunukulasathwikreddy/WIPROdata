using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4TopicsPart2
{
    class VotingException : ApplicationException
    {
        public VotingException(string error) : base (error)
        {
        }
    }

    class Voting
    {
        public void Check(int n)
        {
            if(n < 18)
            {
                throw new VotingException("Less than 18 are Ineligible for voting");
            }
            else
            {
                Console.WriteLine("Eligible for voting");
            }
        }
    }

    internal class F_CustomException
    {
        static void Main(string[] args)
        {
            Voting voting = new Voting();
            try
            {
                voting.Check(17);
            }
            catch (VotingException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            { 
                Console.WriteLine(e); 
            }
        }
        
    }
}
