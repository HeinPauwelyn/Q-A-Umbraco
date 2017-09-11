using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AlaQAndA.WebApp.Models;
using Umbraco.Core.Models;

namespace AlaQAndA.WebApp.Service
{
    public class QuestionService
    {
        private const string _filename = @"G:\hein\ala q&a\q&a.csv";

        public void WriteFile(List<Question> questions)
        {
            StreamWriter file = new StreamWriter(_filename);

            foreach (Question question in questions)
            {
                file.WriteLine("{0},{1}", question.Title, question.Description);
            }

            file.Close();
        }

        public List<Question> ReadFile()
        {
            List<Question> list = new List<Question>();

            string[] lines = System.IO.File.ReadAllLines(_filename);
            int index = 1;

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                string[] splitted = line.Split(',');

                list.Add(new Question(index++, splitted[0], splitted[1]));
            }

            return list;
        }

        public IEnumerable<Question> DeleteRow(int rowId)
        {
            List<Question> questions = ReadFile();
            List<Question> newQuestions = new List<Question>();
            Question deletedQuestion = (from q in questions
                                  where q.ID == rowId
                                  select q).SingleOrDefault();

            foreach (Question q in questions)
            {
                if (!q.Equals(deletedQuestion))
                {
                    newQuestions.Add(q);
                }
            }

            WriteFile(newQuestions);
            return newQuestions;
        }
    }
}