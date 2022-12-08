using System.Collections.Generic;

namespace BlazorServerDataVirtualizationSample.Data
{
    public class PersonalInformationService
    {

        public PersonalInformationService()
        {


        }

        public IList<PersonalInformation> GetPersonalInformationData()
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, @"Data\personal_infomation.csv");

            var data = new List<PersonalInformation>();

            //ファイルをオープンする
            using (StreamReader sr = new StreamReader(filePath))
            {
                var isFirstLineSkip = true;

                while (0 <= sr.Peek())
                {
                    //カンマ区切りで分割して配列で格納する
                    var line = sr.ReadLine()?.Split(',');
                    if (line is null) continue;

                    //先頭行は項目名なのでスキップする
                    if (isFirstLineSkip)
                    {
                        isFirstLineSkip = false;
                        continue;
                    }

                    //リストにデータを追加する
                    data.Add(new PersonalInformation
                    {
                        Id = line[0],
                        Name = line[1],
                        Phone = line[2],
                        BirthDay = line[3]
                    });
                }
            }

            return data;
        }
    }
}
