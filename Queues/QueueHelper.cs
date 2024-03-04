using Queues.Models;
using System;

//using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueHelper
    {
        /// <summary>
        /// פעולת ספירת כמות איברים בתור 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>
        /// 

        //פעולה שסופרת כמה יש בתור
        public static int Count<T>(Queue<T> q)
        {
            int counter = 0;
            //ניצור עותק נוסף של התור
            Queue<T> temp = Copy(q);
            //נרוקן את העותק
            while (!temp.IsEmpty())
            {
                counter++;
                temp.Remove();
            }
            //נחזיר את הכמות
            return counter;
        }
        /// <summary>
        /// פעולה הסופרת כמות איברים בתור ללא שימוש בפעולת עזר
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>

        public static int Count2<T>(Queue<T> q)
        {
            int counter = 0;
            Queue<T> temp = new Queue<T>();
            //נעתיק את הערכים לתור חדש
            while (!q.IsEmpty())
            {
                temp.Insert(q.Remove());
                counter++;
            }
            //נחזיר את הערכים חזרה לתור המקורי
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            //נחזיר את הכמות
            return counter;
        }
        /// <summary>
        /// פעולה היוצרת עותק של התור
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        /// 
        //פעולת קופי של התור
        public static Queue<T> Copy<T>(Queue<T> original)
        {
            Queue<T> copy = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!original.IsEmpty())
            {
                temp.Insert(original.Remove());

            }
            while (!temp.IsEmpty())
            {
                copy.Insert(temp.Head());
                original.Insert(temp.Remove());
            }
            return copy;

        }

        //אם לא כתוב אחרת אסור להרוס את התור

        //פעולה שמחזירה טרו או פולס האם התור ממויין בסדר עולה
        public static bool IsAsc(Queue<int> q)
        {
            int min = int.MaxValue;
            int temphead = int.MaxValue;
            Queue<int> temp = Copy(q);
            while (!temp.IsEmpty())//כל עוד התור לא ריק
            {
                min = temp.Remove();
                if (!temp.IsEmpty())
                { 
                    temphead = temp.Head();
                }
                if (temphead == int.MaxValue)
                {
                    return true;
                }
                if (min > temphead)
                    return false;
            }
            return true;
        }


        //פעולה שמקבלת תור של מספרים שלמים ומחזירה אתצ המינימלי בלי להוציא אותו
        public static int MinVal(Queue<int> q)
        {
            if(q.IsEmpty())
                return int.MinValue;
            Queue<int> temp = Copy(q);
            int min = temp.Remove();
            while (!temp.IsEmpty())
            {
                if (min > temp.Head())
                    min = temp.Remove();
                else temp.Remove();
            }
            return min;
        }

        //פעולה שמקבלת תור שלמים ומוציאה את המינימלי
        public static void Removemin(Queue<int> q)
        {
            int min = MinVal(q);
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (q.Head() != min)
                    temp.Insert(q.Remove());
                else
                    q.Remove();
            }
            while(!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }

        ////פעולה שמקבלת תור ומחזירה תור חדש ממויין בסדר עולה
        //public static Queue<int> OrderAsc(Queue<int> q)
        //{
        //    Queue<int> temp = Copy(q);
        //    Queue<int> result = new Queue<int>();
        //    while (!temp.IsEmpty())
        //    {
        //        result.Insert(MinVal(temp));
        //        Removemin(q);
        //    }
        //    return result;
        //}
        //פעולה שמקבלת תור ומחזירה תור חדש ממויין
        public static Queue<int> OrderAsc2(Queue<int> q)
        {
            Queue<int> temp = Copy(q);//O(n)
            Queue<int> result = new Queue<int>();//O(1)
            while (!temp.IsEmpty()) // n
            {
                result.Insert(MinVal(temp));//O(n)
                Removemin(temp);//O(n)
            }
            return result;
        }


        //פעולה שמכניסה איבר חדש לתור
        //הדוגמה שלי שעובדת טוב מאוד
        public static void EnterMiddle<T>(Queue<T> q, T val)
        {
            int numevarim = Count(q);//כמות איברים בתור
            Queue<T> queue = new Queue<T>();//תור עזר
            int i = 0;
            while (i<numevarim)
            {
               
                if (numevarim / 2 == i)
                {
                    queue.Insert(val);
                }    
                queue.Insert(q.Remove());
                i++;
            }

            while (!queue.IsEmpty())
            {
                q.Insert(queue.Remove());
            }
        }

        //פעולה המכניסה לאמצע התור 
        public static void InsertToMiddle<T>(Queue<T> q, T value)
        {
            Queue<T> temp = new Queue<T>();//תור עזר    
            int count = Count(q);//מספר האיברים בתור
            for (int i = 0; i < count / 2; i++)//נכניס חצי מאיברי התור לתור העזר
                temp.Insert(q.Remove());
            temp.Insert(value);//נכניס את האיבר החדש לתור העזר (בדיוק באמצע)
            while (!q.IsEmpty())
                temp.Insert(q.Remove());//נעביר את החצי השני לתור העזר
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());//נחזיר את כל האיברים לתור המקורי
        }


        //פעולה שמקבלת תור שלמים גדולים מ0 וחזיר את כמות האיברים בתור ותשמור על המקורי. בלי קופי
        //כל המספרים בתור גדולים מ0
        public static int CountNoCopy(Queue<int> q)
        {
            int counter = 0;
            q.Insert(-1);
            while (q.Head() != -1)
            {
                counter++;
                q.Insert(q.Remove());
            }
            q.Remove();
            return counter; 
        }
        //אם ידוע לנו משהו על ערכי התור אניחנו יכולים להשתמנש בערכים ולא בקופי כדי להכניס משהו דמה ולהוציא בסוף

        //פעולה שסופרת כמה יש בלי קופי - נכניס דמה לתור 
        public static int CountWithDummy(Queue<int> q)
        {
            //רק אם ידוע לנו משהו על החוקיות של הערכים בתור
            //נוכל להשתמש באפשרות זו

            int counter = 0;
            q.Insert(-1);//ידוע שכל הערכים בתור גדולים מ-0
            while (q.Head() != -1)//נדע שהגענו לסוף התור אם הגענו לערך הלא חוקי שהכנסנו
            {
                counter++;
                q.Insert(q.Remove());//נדחוף את האיבר שהוצאנו בצורה מעגלית (כלומר לסוף התור)
            }
            q.Remove();//לא לשכוח להעיף את הערך הלא חוקי שנמצא בראש התור
            return counter;
        }


        //עמוד 152
        //7-11

        //לשאול את טלסי
        //לבדוק
        public static void MergeTorim(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> temp = new Queue<int>();
            int countq1 = Count(q1);
            int countq2 = Count(q2);
            if (countq1 > countq2)//אם התור הראשון גדול מהתור השני נכניס קודם את הערכים של התור הראשון
            {
                while (!q2.IsEmpty())
                {
                    temp.Insert(q1.Remove());
                    temp.Insert(q2.Remove());
                }
                while (!q1.IsEmpty())
                {
                    temp.Insert(q1.Remove());
                }
            }
            else //אם התורים שווים או שתיים גדול מאחד נכניס קודם את שתץיים כי ככה בא לי
            {
                while (!q1.IsEmpty())
                {
                    temp.Insert(q2.Remove());
                    temp.Insert(q1.Remove());
                }
                while (!q2.IsEmpty()) 
                {
                    temp.Insert(q2.Remove());
                }
            }
            //כשיצאתי כל הערכים ממוזגים בטמפ אבל אנחנו לא רוצים תור חדש לכן נכניס לאחד התורים את הכל
            while (!temp.IsEmpty())
            {
                q1.Insert(temp.Remove());
            }
        }

        //public static int CountRecursive(Queue<int> q, Queue<int> temp)
        //{
        //    if (q.IsEmpty())
        //        if (q.IsEmpty())//אם התור ריק נחזיר 0 - תנאי עצירה
        //            return 0;
        //    temp.Insert(q.Remove());
        //    int result = 1 + CountRecursive(q, temp);
        //    q.Insert(temp.Remove());
        //    return result;
        //    temp.Insert(q.Remove());//נשמור בתור העזר את הערך שהוצאנו
        //    int result = 1 + CountRecursive(q, temp);//נספור 1 + כמות האיברים בשאר התור
        //    q.Insert(temp.Remove());//נחזיר את התור למצבו המקורי בחזור
        //    return result;//נחזיר את המונה שלנו

        //    //עבור התור 
        //    //   1->5->6->7    7 ראש התור
        //}

    }
}
