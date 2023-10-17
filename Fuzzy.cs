using System;

public class Fuzzy
{
    private const float m = (float)0.2;
    private float pt=0;   // puan
    char tani;
    int dkotu, dorta, diyi;
    public void setpt(float x)
    {
        pt = x;
    }
    char tanilama()
    {
        if (pt < 5.0)
            return '0';
        else if (pt > 5.0)
            return '1';
        else
            return '2';
    }
    float uyelikKotu()
    {
        tani = tanilama();
        switch (tani)
        {
            case '0':
                return (float)(1.0 - m * pt); break;
            case '1':
                return 0; break;
            case '2':
                return 0; break;

            default:
                return 0; break;
        }
    }
    float uyelikOrta()
    {
        tani = tanilama();
        switch (tani)
        {
            case '0':
                return m * pt; break;
            case '1':
                return (float)(2.0 - m * pt); break;
            case '2':
                return (float)1.0; break;
            default:
                return 0; break;
        }
    }
    float uyelikIyi()
    {
        tani = tanilama();
        switch (tani)
        {
            case '0':
                return 0; break;
            case '1':
                return (float)(-1.0 + (m * pt)); break;

            default:
                return 0; break;
        }
    }
    float gc()      
    {
        float d1, d2, d3;
        d1 = uyelikKotu();
        d2 = uyelikOrta();
        d3 = uyelikIyi();

        return (d1 + d2 + d3) * pt;
    }
    public float yuzdeBahsis()
    {
        float x = gc();
        return (float)(x * 2.5);
    }

};
