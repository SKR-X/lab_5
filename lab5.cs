using System;

namespace ConsoleApp10
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("1.1 Ответ:");
            Console.WriteLine($"8: {Cnk(8)}, 10: {Cnk(10)}, 11: {Cnk(11)}");

            Console.WriteLine("1.2 Ответ:");
            Console.WriteLine(CompareTriangles());

            int[] a1 = new int[7] {1,2,3,4,5,6,7};
            int[] a2 = new int[8] {1,8,2,3,4,5,6,7};
            int max1 = ArrayMaxId(a1);
            int max2 = ArrayMaxId(a2);
            a1 = ArrayRemoverAtId(a1,max1);
            a2 = ArrayRemoverAtId(a2,max2);
            a1 = UnitArrays(a1,a2);
            Console.WriteLine("2.6 Ответ:");
            for (int i = 0; i < a1.Length; i++)
            {
                Console.Write($"{a1[i]} ");
            }
            
            int[,] matrix = { {1,2,3,4},
                              {1,2,7,4},
                              {1,2,3,4},
                              {1,2,3,4} };
            int[] ids = findColumnsIds(matrix);
            matrix = DeleteColumnFromMatrix(matrix,ids[0],ids[1]);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            double[,] matrix1 = {{1,2,3,4,5},
                       {6,7,8,9,10},
                       {11,12,13,14,15}};
            double[,] matrix2 = {{5,5,5,5,5},
                       {1,1,1,1,1},
                       {1,1,1,1,1}};
            double[,] matrixEdit1 = FindMaxes(matrix1);
            double[,] matrixEdit2 = FindMaxes(matrix2);
            Console.WriteLine("2.23 Ответ:");
            showDoubleMatrix(matrixEdit1);
            Console.WriteLine();
            showDoubleMatrix(matrixEdit2);
            double aa1 = 0.1, bb1 = 1, hh1 = 0.1, aa2 = Math.PI / 5, bb2 = Math.PI, hh2 = Math.PI / 25;
            Console.WriteLine("3.1 Ответ:");
            Console.WriteLine($"{1 + Sum(f1, aa1, bb1, hh1)}");
            Console.WriteLine($"{Sum(f2, aa2, bb2, hh2)}");
            int[,] matrixTypes = { {1,2,3,4,5},
                                   {5,4,3,2,1},
                                   {6,7,8,9,10},
                                   {10,9,8,7,6} };
            int[] row = new int[matrixTypes.GetLength(1)];
            fdRow type;
            for (int i = 0; i < matrixTypes.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTypes.GetLength(1); j++)
                {
                    row[j] = matrixTypes[i, j];
                }
                if ((i+1)%2==0)
                {
                    type = fRowEven;
                } else
                {
                    type = fRowNotEven;
                }
                row = type(row);
                for (int j = 0; j < matrixTypes.GetLength(1); j++)
                {
                    matrixTypes[i,j] = row[j];
                }
            }
            Console.WriteLine("3.2 Ответ:");
            for (int i = 0; i < matrixTypes.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTypes.GetLength(1); j++)
                {
                    Console.Write(matrixTypes[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        delegate int[] fdRow(int[] row);

        static int[] fRowEven(int[] row)
        {
            int sortIndex = 0;
            int temp = 0;
            while (sortIndex < row.Length)
            {
                if (sortIndex == 0 || row[sortIndex] >= row[sortIndex - 1])
                {
                    sortIndex++;
                }
                else
                {
                    temp = row[sortIndex];
                    row[sortIndex] = row[sortIndex - 1];
                    row[sortIndex - 1] = temp;
                    sortIndex--;
                }
            }
            return row;
        }

        static int[] fRowNotEven(int[] row)
        {
            int sortIndex = 0;
            int temp = 0;
            while (sortIndex < row.Length)
            {
                if (sortIndex == 0 || row[sortIndex] <= row[sortIndex - 1])
                {
                    sortIndex++;
                }
                else
                {
                    temp = row[sortIndex];
                    row[sortIndex] = row[sortIndex - 1];
                    row[sortIndex - 1] = temp;
                    sortIndex--;
                }
            }
            return row;
        }
        static void showDoubleMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static int Fact(int num)
        {
            int result = 1;
            while(num>1)
            {
                result *= num;
                num = num - 1;
            }
            return result;
        }

        static int Cnk(int n)
        {
                return (Fact(n) / (Fact(n - 5) * Fact(5)));
        }

        static String CompareTriangles(int a1 = 3, int a2 = 3, int a3 = 3, int b1 = 5, int b2 = 6, int b3 = 7)
        {
            double p1 = (a1 + a2 + a3) / 2;
            double p2 = (b1+b2+b3) / 2;
            double s1 = Math.Sqrt(p1*(p1-a1)*(p1-a2)*(p1-a3));
            double s2 = Math.Sqrt(p2 * (p2 - b1) * (p2 - b2) * (p2 - b3));
            if(s1==s2)
            {
                return "equals";
            } else if (s1>s2)
            {
                return "s1>s2";
            } else
            {
                return "s1<s2";
            }
        }
        
        static int ArrayMaxId(int[] arr)
        {
            int max = arr[0];
            int maxi = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i]>max)
                {
                    max = arr[i];
                    maxi = i;
                }
            }
            return maxi;
        }
        static int[] ArrayRemoverAtId(int[] arr, int id)
        {
            int[] resultArr = new int[arr.Length-1];
            int c = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i!=id) {
                    resultArr[c] = arr[i];
                    c++;
                }
            }

            return resultArr;
        }

        static int[] UnitArrays(int[] a1, int[] a2)
        {
            int[] resultArr = new int[a1.Length + a2.Length];

            for (int i = 0; i < a1.Length; i++)
            {
                resultArr[i] = a1[i];
            }
            int c = 0;
            for (int i = a1.Length; i < resultArr.Length; i++)
            {
                resultArr[i] = a2[c];
                c++;
            }

            return resultArr;
        }

        static int[] findColumnsIds(int[,] matrix)
        {
            int[] ids = new int[2];
            int c = 0,max = 0, i = 0, maxj = 0, min = matrix[0,matrix.GetLength(0)-1], minj = matrix.GetLength(0)-1;
            while(i < matrix.GetLength(0))
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i,j]>max)
                    {
                        max = matrix[i, j];
                        maxj = j;
                    }
                }
                i++;
            }
            ids[0] = maxj;
            i = 0;
            while (i < matrix.GetLength(0))
            {
                for (int j = matrix.GetLength(0)-1; j > i; j--)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minj = j;
                    }
                }
                i++;
            }
            ids[1] = minj;
            return ids;
        }

        static int[,] DeleteColumnFromMatrix(int[,] matrix, int jD1, int jD2)
        {
            int c = 0;
            int[,] resMatrix = new int[matrix.GetLength(0),matrix.GetLength(1)-2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j!=jD1 && j!=jD2)
                    {
                        resMatrix[i,c] = matrix[i, j];
                        c++;
                    }
                }
            }

            return resMatrix;
        } 

        static double[,] FindMaxes(double[,] matrix)
        {
            double[] arr = new double[matrix.GetLength(0)*matrix.GetLength(1)];
            double[] maxes = new double[5];
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr[c] = matrix[i,j];
                    c++;
                }
            }

            int sortIndex = 0;
            double temp = 0;
            while(sortIndex < arr.Length)
            {
                if (sortIndex==0 || arr[sortIndex] <= arr[sortIndex-1])
                {
                    sortIndex++;
                } else
                {
                    temp = arr[sortIndex];
                    arr[sortIndex] = arr[sortIndex - 1];
                    arr[sortIndex - 1] = temp;
                    sortIndex--;
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                maxes[i] = arr[i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == maxes[0] || matrix[i, j] == maxes[1] || matrix[i, j] == maxes[2] || matrix[i, j] == maxes[3] || matrix[i, j] == maxes[4])
                    {
                        if (matrix[i,j]>0)
                        {
                            matrix[i, j] *= 2;
                        } else
                        {
                            matrix[i, j] = matrix[i, j] / 2;
                        }
                    } else
                    {
                        if (matrix[i, j] > 0)
                        {
                            matrix[i, j] = matrix[i, j] / 2;
                        }
                        else
                        {
                            matrix[i, j] *= 2;
                        }
                    }
                }
            }

            return matrix;
        }

        delegate double fd(double x, int i);
        static double f1(double x, int i)
        {
            return Math.Cos(i * x) / Fact(i);
        }
        static double f2(double x, int i)
        {
            return Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
        }
        static double Sum(fd f, double a, double b, double h)
        {
            double s = 0;
            int i = 1;
            for (double x = a; x <= b; x = x + h)
            {
                s = s + f(x, i);
                i++;
            }
            return s;
        }
    }
}
