using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Solver
    {
        List<string> zList = new List<string> { "W", "N", "E", "S" };
        int[] Xy = new int[2] { 0, 0 };
        int Z = 0;
        int gridX = 0, gridY = 0;

        public string[] Run(int maxX, int maxY, int x, int y, string z, List<string> steps)
        {

            gridX = maxX;
            gridY = maxY;

            Xy[0] = x;
            Xy[1] = y;
            try { Z = zList.IndexOf(z); }
            catch { throw new IndexOutOfRangeException("Direction should be in one of N,W,S,E"); }

            Turn(steps);
            if (CheckIfOutOfGrid(x, y)) { throw new IndexOutOfRangeException("Position is over grid"); }

            return new string[3] { Xy[0].ToString(), Xy[1].ToString(), zList[Z] };

        }


        private void Turn(List<string> steps)
        {
            string N = zList[Z];
            foreach (string step in steps)
            {
                switch (step)
                {
                    case "L":
                        Z--;
                        Z = Mod(Z, 4);
                        N = zList[Z];

                        break;
                    case "R":
                        Z++;
                        Z = Mod(Z, 4);
                        N = zList[Z];

                        break;
                    case "M":
                        Move(N);

                        break;
                }
            }
        }

        private void Move(string step)
        {
            switch (step)
            {
                case "N":
                    Xy[1] += 1;
                    break;
                case "S":
                    Xy[1] -= 1;
                    break;
                case "E":
                    Xy[0] += 1;
                    break;
                case "W":
                    Xy[0] -= 1;
                    break;
                default:
                    break;
            }
        }
        private bool CheckIfOutOfGrid(int x, int y)
        {
            return x > gridX || y > gridY || x < 0 || y < 0;
        }

        //fix odd neg mod opration
        private int Mod(int a, int b)
        {
            if (a >= 0 && b >= 0) { return a % b; }
            else if (a <= 0 && b <= 0) { return Math.Abs(a % b); }
            else { return (a % b) + b; }
        }

    }
}
