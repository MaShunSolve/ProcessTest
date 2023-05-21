using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        //創建ProcessStartInfo，指定要執行的命令和參數
        ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c invalidcommand");

        //指定為標準輸出和標準錯誤出創建一個新的 Process
        Process process = new Process();
        process.StartInfo = psi;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;//不填.net framework預設為true .netcore預設為false，為true的時候無法使用RedirectOutput

        //開始並等待完成
        process.Start();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
        Console.WriteLine($"Error:{process.StandardError.ReadToEnd()}");
        process.WaitForExit();
    }
}