using System;

namespace StudentProgressFuzzyLogic.FuzzyLogic
{
    public static class MemFunc
    {
        public enum MEMEBER_FUNCTION_TYPE
        {
            TRAPMF,
            TRIMF,
            SMF,
            ZMF
        }

        public static float? MembershipFunction(float x, float[] args, MEMEBER_FUNCTION_TYPE member_function_type)
        {
            float? answer = null;

            switch (member_function_type)
            {
                case MEMEBER_FUNCTION_TYPE.TRAPMF:
                    answer = trapmf(x, args);
                    break;

                case MEMEBER_FUNCTION_TYPE.TRIMF:
                    answer = trimf(x, args);
                    break;

                case MEMEBER_FUNCTION_TYPE.SMF:
                    answer = smf(x, args);
                    break;

                case MEMEBER_FUNCTION_TYPE.ZMF:
                    answer = zmf(x, args);
                    break;

                default:
                    throw WrongTypeExecption();
            }

            return answer;
        }

        public static float[] MembershipFunction(float[] X, float[] args, MEMEBER_FUNCTION_TYPE member_function_type)
        {
            float[] answer = new float[X.Length];

            for (int xIndex = 0; xIndex < X.Length; xIndex++)
            {
                switch (member_function_type)
                {
                    case MEMEBER_FUNCTION_TYPE.TRAPMF:
                        answer[xIndex] = (float)Math.Round(trapmf(X[xIndex], args),5);
                        break;

                    case MEMEBER_FUNCTION_TYPE.TRIMF:
                        answer[xIndex] = (float)Math.Round(trimf(X[xIndex], args),5);
                        break;

                    case MEMEBER_FUNCTION_TYPE.SMF:
                        answer[xIndex] = (float)Math.Round(smf(X[xIndex], args),5);
                        break;

                    case MEMEBER_FUNCTION_TYPE.ZMF:
                        answer[xIndex] = (float)Math.Round(zmf(X[xIndex], args),5);
                        break;

                    default:
                        throw WrongTypeExecption();
                }
            }

            return answer;
        }

        private static float trapmf(float x, float[] args)
        {
            if (args.Length != 4)
                throw WrongTypeExecption();

            float a = args[0], b = args[1], c = args[2], d = args[3];

            if (x < a)
                return 0;
            else if (a <= x && x < b)
                return (x - a) / (b - a);
            else if (b <= x && x <= c)
                return 1;
            else if (c < x && x <= d)
                return (d - x) / (d - c);

            return 0;

            //return Math.Max(Math.Min(Math.Min((x - a) / (b - a), (d - x) / (d - c)), 1), 0);
        }

        private static float trimf(float x, float[] args)
        {
            if (args.Length != 3)
                throw WrongTypeExecption();

            float a = args[0], b = args[1], c = args[2];

            if (x < a)
                return 0;
            else if (a <= x && x < b)
                return (x - a) / (b - a);
            else if (x == b)
                return 1;
            else if (b < x && x <= c)
                return (c - x) / (c - b);
            return 0;

            //return Math.Max(Math.Min((x-a)/(b-a), (c-x)/(c-b)), 0);
        }

        private static float smf(float x, float[] args)
        {
            if (args.Length != 2)
                throw WrongTypeExecption();

            float a = args[0], b = args[1], answer = 0;

            if (a <= x && x <= (a + b) / 2f)
                answer = (float)(2f * Math.Pow((x - a) / (b - a), 2f));

            if ((a + b) / 2f <= x && x <= b)
                answer = 1f - (float)(2f * Math.Pow((x - b) / (b - a), 2f));

            if (x > b)
                answer = 1;

            return answer;
        }

        private static float zmf(float x, float[] args)
        {
            if (args.Length != 2)
                throw WrongTypeExecption();

            float a = args[0], b = args[1], answer = 1;

            if (a <= x && x <= (a + b) / 2f)
                answer = 1f - (float)(2f * Math.Pow((x - a) / (b - a), 2f));

            if ((a + b) / 2f <= x && x <= b)
                answer = (float)(2f * Math.Pow((x - b) / (b - a), 2f));

            if (x > b)
                answer = 0;

            return answer;
        }

        private static Exception WrongTypeExecption()
        {
            return new Exception("Wrong count of arrgs or membership function type");
        }
    }
}
