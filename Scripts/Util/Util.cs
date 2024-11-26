class Util 
{
    public static bool RandTrigger(float rate) 
    {
        Random ran = new();
        int n = ran.Next(0, 100);
        return n / 100 <= rate;
    }
}

