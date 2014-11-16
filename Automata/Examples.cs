using System;
using System.Collections.Generic;
using System.Linq;

namespace Automata
{
    public static class Examples
    {
        public static List<State<string>> DocumentStates()
        {
            var draft = new State<string>("draft");
            var pending = new State<string>("pending");
            var approved = new State<string>("approved");
            var deleted = new State<string>("deleted");
            var archived = new State<string>("archived");

            draft.To(pending).On("send-to-approval");
            draft.To(deleted).On("delete");

            pending.To(approved).On("approve");
            pending.To(deleted).On("delete");
            //pending.To(draft).On("reject");

            approved.To(archived).On("archive");

            archived.To(deleted).On("delete");
            archived.To(approved).On("unarchive");

            return new List<State<string>> { draft, pending, approved, deleted, archived };
        }

        public static List<State<string>> SimpleBabyStates()
        {
            var happy = new State<string>("nappy");
            var screaming = new State<string>("screaming");
            var sleeping = new State<string>("sleeping");
            var diaper = new State<string>("diaperchange");

            happy.To(happy).On("tickle").Do(() => Console.WriteLine("Giggle!"));
            happy.To(screaming).On("hungry").Do(() => Console.WriteLine("Waah!"));
            //happy.To(screaming).On("sleepy");
            happy.To(diaper).On("poo").Do(() => Console.WriteLine("..."), () => { throw new Exception(); });

            screaming.To(sleeping).On("lullaby");
            //screaming.To(sleeping).On("milk");
            screaming.To(happy).On("rattle");

            sleeping.To(screaming).On("wake").Do(() => Console.WriteLine("Waaaaah! Wahaah!"));

            diaper.To(happy).On("change");
            diaper.To(screaming).On("lullaby");
            //diaper.To(screaming).On("rattle");

            return new List<State<string>> { happy, screaming, sleeping, diaper };
        }

        public static List<State<string>> BabyStates()
        {
            var happy = new State<string>("happy");
            var unhappy = new State<string>("unhappy");
            var hungry = new State<string>("hungry");
            var teething = new State<string>("teething");
            var sleepy = new State<string>("sleepy");
            var sleeping = new State<string>("sleeping");
            var diaper = new State<string>("diaperchange");

            happy.To(happy).On("tickle").Do(() => Console.WriteLine("Giggle"));
            happy.To(hungry).On("hungry");
            happy.To(sleepy).On("sleepy");
            happy.To(diaper).On("poo");
            happy.To(teething).On("tooth");

            unhappy.To(happy).On(s => new[] { "tickle", "rattle", "milk" }.Contains(s));
            unhappy.To(unhappy).On(s => !(new[] { "tickle", "rattle", "milk" }.Contains(s)));

            hungry.To(happy).On("milk");
            hungry.To(hungry).On("lullaby");

            sleepy.To(sleepy).On("milk");
            sleepy.To(sleeping).On("lullaby");

            sleeping.To(unhappy).On("wake").Do(() => Console.WriteLine("Waaaaah! Wahaah!"));

            teething.To(sleepy).On("sleepy");
            teething.To(diaper).On("poo");
            teething.To(hungry).On("hungry");

            diaper.To(happy).On("change");
            diaper.To(diaper).On("lullaby");

            return new List<State<string>> { happy, unhappy, hungry, teething, sleepy, sleeping, diaper };
        }

        public static List<State<string>> MoodStates()
        {
            var neutral = new State<string>("neutral");
            var drunk = new State<string>("drunk");
            var happy = new State<string>("happy");
            var moody = new State<string>("moody");
            var angry = new State<string>("angry");

            neutral.To(happy).On("tickle");
            neutral.To(moody).On("hassle");
            neutral.To(drunk).On(s => s.Contains("beer"));

            moody.To(angry).On("tickle");
            moody.To(neutral).On(s => s.Contains("beer"));

            happy.To(neutral).On(s => "hassle".Equals(s));

            return new List<State<string>> { neutral, moody, happy, angry, drunk };
        }
    }
}
