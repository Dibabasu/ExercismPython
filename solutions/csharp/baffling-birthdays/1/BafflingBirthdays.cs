public static class BafflingBirthdays
{
    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
{
    DateOnly[] birthdates = new DateOnly[numberOfBirthdays];
    Random random = new Random();
    int days = 0;
    int month = 0;
    int year = 0;
    for (int i = 0; i < numberOfBirthdays; i++)
    {
        GenerateRandomDate(random, out year, out month, out days);
        birthdates[i] = new DateOnly(year, month, days);
    }
    return birthdates;
}

private static void GenerateRandomDate(Random random, out int year, out int month, out int days)
{
    year = random.Next(2005, 2008);
    month = random.Next(1, 13);
    if (month == 2)
    {
        days = random.Next(1, 29);
    }
    else if (month == 4 || month == 6 || month == 9 || month == 11)
    {
        days = random.Next(1, 31);
    }
    else
    {
        days = random.Next(1, 32);
    }
}

public static bool SharedBirthday(DateOnly[] birthdays)
{
    for(int i = 0; i < birthdays.Length; i++)
    {
        for (int j = i + 1; j < birthdays.Length; j++)
        {
            if (birthdays[i].Month == birthdays[j].Month && birthdays[i].Day == birthdays[j].Day)
            {
                return true;
            }
        }
    }
    return false;
}

public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
{
     if (numberOfBirthdays < 2) return 0.0;

 double probabilityNoShared = 1.0;
 int daysInYear = 365;

 for (int i = 0; i < numberOfBirthdays; i++)
 {
     probabilityNoShared *= (daysInYear - i) / (double)daysInYear;
 }

 return (1.0 - probabilityNoShared)*100;
}
}
