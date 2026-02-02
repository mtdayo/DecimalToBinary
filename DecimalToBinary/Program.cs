using System;

public class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("説明 : 10進数を2進数に変えます。0以上65535以下の整数値を入力して下さい。終了するためには「end」と入力してください。");
        while (true)    //endと入力されるまで繰り返し処理
        {

            Console.Write($"10進数 : ");
            string? decimal_input = Console.ReadLine();

            if (decimal_input == "end")
            {
                break;
            }
            if (int.TryParse(decimal_input, out int value))    //int型に変換
            {
                if (0 <= value && value <= 65535)    //0以上65535以下か判定する
                {
                    Bit16_bin(value);    //2進数に変換し出力する
                }
                else
                {
                    Console.WriteLine("0以上65535以下の整数値を入力して下さい。");    //0未満65536以上の場合入力待機
                }
            }
            else
            {
                Console.WriteLine("整数値を入力して下さい。");    //整数値出ない場合入力待機
            }


        }


    }


    public static void Bit16_bin(int value)    //65535以下の整数値を2進数に変換するメソッド
    {
        int[] array_pow = { 32768, 16384, 8192, 4096, 2048, 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };    //2進数を求めるための配列
        int remaining = value;
        string result = "";    //resultで初期化
        foreach (var pow in array_pow)
        {

            if (remaining - pow < 0)    //結果が0未満になった場合
            {
                if (result == "")    //先頭が0になるのを防ぐため
                {
                    continue;
                }
                else
                {
                    result += "0";
                }
            }
            else    //結果が0以上になった場合
            {
                result += "1";
                remaining -= pow;

            }

        }
        if (value == 0)    //0の場合0を返す
        {
            Console.WriteLine("2進数 : 0");
            return;
        }
        Console.WriteLine($"2進数 : {result}");    //2進数を出力する
    }


}
