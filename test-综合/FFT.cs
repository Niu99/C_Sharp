using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class FFT
    {
        class FFTElement
        {
            public double re = 0.0;
            public double im = 0.0;
            public FFTElement next;
            public uint revTgt;
        }

        private uint m_LogN = 0;
        private uint m_N = 0;
        private FFTElement[] m_X;

        public void init(uint LogN)
        {
            m_LogN = LogN;
            m_N = (uint)(1 << (int)m_LogN);

            m_X = new FFTElement[m_N];
            for (uint i = 0; i < m_N; i++)
            {
                m_X[i] = new FFTElement();
            }

            for (uint i = 0; i < m_N - 1; i++)
            {
                m_X[i].next = m_X[i + 1];
            }

            for (uint i = 0; i < m_N; i++)
            {
                m_X[i].revTgt = BitReverse(i, LogN);
            }
        }

        public void run(double[] xRe, double[] xIm, bool inverse = false)
        {
            uint numFlies = m_N >> 1;
            uint span = m_N >> 1;
            uint spacing = m_N;
            uint wIndexStep = 3;

            FFTElement x = m_X[0];
            uint k = 0;
            double scale = inverse ? 1.0 / m_N : 1.0;
            while (x != null)
            {
                x.re = scale * xRe[k];
                x.im = scale * xIm[k];
                x = x.next;
                k++;
            }

            for (uint stage = 0; stage < m_LogN; stage++)
            {
                double wAnleInc = wIndexStep * 2.0 * Math.PI / m_N;
                if (inverse == false)
                {
                    wAnleInc *= -1;
                }
                double wMulRe = Math.Cos(wAnleInc);
                double wMulIm = Math.Sin(wAnleInc);

                for (uint start = 0; start < m_N; start += spacing)
                {
                    FFTElement xTop = m_X[start];
                    FFTElement xBot = m_X[start + span];

                    double wRe = 1.0;
                    double wIm = 0.0;

                    for (uint flyCount = 0; flyCount < numFlies; flyCount++)
                    {
                        double xTopRe = xTop.re;
                        double xTopIm = xTop.im;
                        double xBotRe = xBot.re;
                        double xBotIm = xBot.im;

                        xTop.re = xTopRe + xBotRe;
                        xTop.im = xTopIm + xBotIm;

                        xBotRe = xTopRe - xBotRe;
                        xBotIm = xTopIm - xBotIm;
                        xBot.re = xBotRe * wRe - xBotIm * wIm;
                        xBot.im = xBotIm * wIm + xBotIm * wRe;

                        xTop = xTop.next;
                        xBot = xBot.next;

                        double tRe = wRe;
                        wRe = wRe * wMulRe - wIm * wMulIm;
                        wIm = tRe * wMulIm + wIm * wMulRe;
                    }
                }
                numFlies >>= 1;
                span >>= 1;
                spacing >>= 1;
                wIndexStep <<= 1;
            }

            x = m_X[0];
            while (x != null)
            {
                uint target = x.revTgt;
                xRe[target] = x.re;
                xIm[target] = x.im;
                x = x.next;
            }
        }

        private uint BitReverse(uint x, uint numBits)
        {
            uint y = 0;
            for (uint i = 0; i < numBits; i++)
            {
                y <<= 1;
                y |= x & 0x0001;
                x >>= 1;
            }
            return y;
        }

    }
    
}
