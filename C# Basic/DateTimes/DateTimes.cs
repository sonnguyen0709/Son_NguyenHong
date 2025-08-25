using System;

namespace DateTimeDataType
{
    class Program
    {
        static void Main()
        {

            //Khoi tao ngay thang
            DateTime now = DateTime.Now; //Khoi tao thoi gian hien tai
            Console.WriteLine($"Current date and time: {now}.");
            DateTime birthDate = new DateTime(2001, 9, 7); //Khoi tao mot thoi diem bat ky voi ngay, thang, nam
            DateTime myDay = new DateTime(2024, 9, 7, 19, 30, 0);//Khoi tao voi ca thoi gian
            Console.WriteLine($"Birthdate: {birthDate}");

            //Lay tung thanh phan cua DateTime
            Console.WriteLine($"Year: {now.Year}");
            Console.WriteLine($"Month: {now.Month}");
            Console.WriteLine($"Day: {now.Day}");
            Console.WriteLine($"Day of week: {now.DayOfWeek}");
            Console.WriteLine($"Hour: {now.Hour}");
            Console.WriteLine($"Minute: {now.Minute}");
            Console.WriteLine($"Second: {now.Second}");

            //Them bot thoi gian
            DateTime tomorrow = now.AddDays(1);
            Console.WriteLine($"Tomorrow: {tomorrow.ToShortDateString()}"); // tra ve gia tri khong co thoi gian
            DateTime thirtyMinutesAgo = now.AddMinutes(-30);
            Console.WriteLine($"30 minutes ago: {thirtyMinutesAgo.ToLongTimeString()}");// tra ve gia tri co ca thoi gian

            //TimeSpan : 1 khoang thoi gian hoac chenh lech 2 DateTime
            DateTime begin = new DateTime(2025, 7, 10, 8, 30, 0); // 8h sang
            DateTime end = new DateTime(2025, 7, 10, 17, 30, 0); // 11h15
            TimeSpan span = end - begin;
            Console.WriteLine($"\nKhoang thoi gian lam viec: {span}");

            //So sanh 2 DateTime
            DateTime d1 = new DateTime(2025, 7, 10);
            DateTime d2 = new DateTime(2025, 7, 11);
            Console.WriteLine($"\nd1 == d2? {d1 == d2}");
            Console.WriteLine($"d1 != d2? {d1 != d2}");
            Console.WriteLine($"d1 > d2? {d1 > d2}");
            Console.WriteLine($"d1 < d2? {d1 < d2}");
            Console.WriteLine($"d1 >= d2? {d1 >= d2}");
            Console.WriteLine($"d1 <= d2? {d1 <= d2}");

            //Dinh dang lai dau ra
            Console.WriteLine($"Format dd/MM/yyyy: {now:dd/MM/yyyy}");
            Console.WriteLine($"Format HH:mm:ss: {now:HH:mm:ss}");
            Console.WriteLine($"Full format: {now:dddd, dd MMMM yyyy HH:mm:ss}");

            //Check nam nhuan
            int year = 2025;
            bool isLeapYear = DateTime.IsLeapYear(year);
            Console.WriteLine($"{year} {(isLeapYear ? "is" : "is not")} a leap year");

            //DateOnly va TimeOnly
            DateOnly onlyDate = DateOnly.FromDateTime(now);
            TimeOnly onlyTime = TimeOnly.FromDateTime(now);
            Console.WriteLine($"DateOnly: {onlyDate}");
            Console.WriteLine($"TimeOnly: {onlyTime}");

            //Parse va TryParse
            //Parse chuyen chuoi thanh DateTime theo dinh dang he thong
            string dateStr1 = "10/07/2025";
            DateTime dt1 = DateTime.Parse(dateStr1);
            Console.WriteLine($"Parse: {dt1}");

            //TryParse chuyen chuoi thanh DateTime, neu sai tra ve false
            string dateStr2 = "33/05/2025";
            if (DateTime.TryParse(dateStr2, out DateTime dt3))
            {
                Console.WriteLine($"TryParse thanh cong: {dt3}");
            }
            else
            {
                Console.WriteLine("TryParse that bai!");
            }

            //Lay mui gio hien tai
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            Console.WriteLine($"Local Time Zone: {localZone.DisplayName}");

            //Lay danh sach tat ca mui gio
            foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine($"{tz.Id} | {tz.DisplayName}");
            }

            //Chuyen doi mui gio
            DateTime utcNow = DateTime.UtcNow;//Lay theo mui gio utc
            TimeZoneInfo vietnamTime = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");//Lay mui gio GMT +7
            DateTime vnTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTime);

            Console.WriteLine($"UTC Now   : {utcNow}");
            Console.WriteLine($"Vietnam   : {vnTime}");

            //Chuyen doi giua hai mui gio
            DateTime utcNow1 = DateTime.UtcNow;
            TimeZoneInfo sourceZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            TimeZoneInfo destZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

            DateTime sourceTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow1, sourceZone);
            DateTime destTime = TimeZoneInfo.ConvertTime(sourceTime, sourceZone, destZone);

            Console.WriteLine($"Gio o VN     : {sourceTime}");
            Console.WriteLine($"Gio o Tokyo  : {destTime}");

            //Lay thoi gian co thong tin mui gio
            DateTimeOffset nowWithZone = DateTimeOffset.Now;
            Console.WriteLine($"Local time with offset: {nowWithZone}");
        }
    }
}










