using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace fanalproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = "資料已建好";
            WebRequest com1 = WebRequest.Create(textBox1.Text);
            //com1.Timeout = 10000;
            com1.Method = "GET";
            WebResponse re1 = com1.GetResponse();
            StreamReader s1 = new StreamReader(re1.GetResponseStream());
            string result1 = s1.ReadToEnd();
            FileStream f1 = new FileStream("1.txt", FileMode.Create);
            byte[] data1 = System.Text.Encoding.Default.GetBytes(result1);
            f1.Write(data1, 0, result1.Length);
            re1.Close();
            s1.Close();
            f1.Flush();
            f1.Close();
            data1 = null;

            /*2*/
            WebRequest com2 = WebRequest.Create(textBox2.Text);
            com2.Method = "GET";
            //com2.Timeout = 10000;
            WebResponse re2 = com2.GetResponse();
            StreamReader s2 = new StreamReader(re2.GetResponseStream());
            string result2 = s2.ReadToEnd();
            FileStream f2 = new FileStream("2.txt", FileMode.Create);
            byte[] data2 = System.Text.Encoding.Default.GetBytes(result2);
            f2.Write(data2, 0, result2.Length);
            re2.Close();
            s2.Close();
            f2.Flush();
            f2.Close();
            data2 = null;
            /*3*/

            WebRequest com3 = WebRequest.Create(textBox3.Text);
            com3.Method = "GET";
            //com3.Timeout = 10000;
            WebResponse re3 = com3.GetResponse();
            StreamReader s3 = new StreamReader(re3.GetResponseStream());
            string result3 = s3.ReadToEnd();
            FileStream f3 = new FileStream("3.txt", FileMode.Create);
            byte[] data3 = System.Text.Encoding.Default.GetBytes(result3);
            f3.Write(data3, 0, result3.Length);
            re3.Close();
            s3.Close();
            f3.Flush();
            f3.Close();
            data3 = null;
            GC.Collect();

            /*stop word*/
            string[] stopword = {"a", "about", "above", "across",
                                "after", "again", "against","all",
                                "almost", "alone", "along", "already",
                                "also", "although",  "always" ,"among",
                                "an",  "and","another", "any", "anybody",
                                "anyone",  "anything", "anywhere", "are",
                                "area", "areas",  "around", "as", "ask",
                                "asked", "asking", "asks","at", "away",
                                "b", "back", "backed", "backing","backs",
                                "be", "became", "because", "become", "becomes",
                                "been","before", "began", "behind", "being",
                                "beings", "best", "better", "between", "big",
                                "both", "but","by", "c","came","can","cannot",
                                "case", "cases","certain", "certainly", "clear",
                                "clearly", "come", "could", "d", "did", "differ",
                                "different", "differently", "do", "does", "done",
                                "down", "downed", "downing", "downs","during", "e",
                                "each","early", "either", "end", "ended", "ending",
                                "ends", "enough", "even", "evenly", "ever", "every",
                                "everybody", "everyone","everything", "everywhere",
                                "f", "face", "faces", "fact", "facts", "far", "felt",
                                "few", "find", "finds", "first", "for", "four", "from",
                                "full", "fully", "further", "furthered", "furthering",
                                "furthers", "g", "gave", "general", "generally", "get",
                                 "gets", "give", "given", "gives", "go", "going", "good",
                                 "goods", "got", "great", "greater", "greatest", "group",
                                 "grouped","grouping","groups","h","had","has","have","having",
                                 "he","her","here","herself","high","higher","highest","him",
                                "himself","his","how","however","i","if","important","in","interest",
                                "interested","interesting","interests","into","is","it","its",
                                "itself","j","just","k","keep","keeps","kind","knew","know","known",
                                "knows","l","large","largely","last","later","latest","least","less",
                                "let","lets","like","likely","long","longer","longest","m","made",
                                "make","making","man","many","may","me","member","members","men",
                                "might","more","most","mostly","mr","mrs","much","must","my",
                                "myself","n","necessary","need","needed","needing","needs","never",
                                "new","newer","newest","next","no","nobody","non","noone","not",
                                "nothing","now","nowhere","number","numbers","o","of","off",
                                "often","old","older","oldest","on","once","one","only","open",
                                "opened","opening","opens","or","order","ordered","ordering",
                                "orders","other","others","our","out","over","p","part","parted",
                                "parting","parts","per","perhaps","place","places","point",
                                "pointed","pointing","points","possible","present","presented",
                                "presenting","presents","problem","problems","put","puts","q",
                                "quite","r","rather","really","right","right","room","rooms",
                                "s","said","same","saw","say","says","second","seconds","see",
                                 "seem","seemed","seeming","seems","sees","several","shall","she",
                                 "should","show","showed","showing","shows","side","sides","since",
                                "small","smaller","smallest","so","somebody","someone","something","somewhere",
                                "state","states","still","still","such","sure","t","take","taken",
                                "than","that","the","their","them","then","there","therefore",
                                "these","they","thing","things","think","thinks","this","those",
                                "though","thought","thoughts","three","through","thus","to",
                                "today","together","too","took","toward","turn","turned","turning",
                                "turns","two","u","under","until","up","upon","us","use","used",
                                "uses","v","very","w","want","wanted","wanting","wants","was",
                                "way","ways","we","well","wells","went","were","what","when",
                                "where","whether","which","while","who","whole","whose","why",
                                "will","with","within","without","work","worked","working",
                               "works","would","x","y","year","years","yet","you","young","younger",
                                "youngest","your","yours","z"};
            global.title = new string[400];
            global.each_composition = new string[400];
            global.top = -1;
            string total_result = result1 + result2 + result3;
            /*save title and every essay*/
            for (int i = 0; i < total_result.Length; i++)
            {
                if (i + 5 < total_result.Length)
                {
                    if ((total_result[i] == '\n' && (total_result[i + 1] >= '0' && total_result[i + 1] <= '9') && total_result[i + 2] == '.' && total_result[i + 3] == ' ')
                    || (total_result[i] == '\n' && (total_result[i + 1] >= '0' && total_result[i + 1] <= '9') && (total_result[i + 2] >= '0' && total_result[i + 2] <= '9') && total_result[i + 3] == '.'
                    && total_result[i + 4] == ' ')
                    || (total_result[i] == '\n' && total_result[i + 1] == '1' && total_result[i + 2] == '0' && total_result[i + 3] == '0' && total_result[i + 4] == '.' && total_result[i + 5] == ' '))
                    {

                        i++;
                        global.top++;
                        int count = 0;
                        for (; i < total_result.Length; i++)
                        {
                            global.title[global.top] = global.title[global.top] + total_result[i];
                            if (total_result[i] == '\n')
                                count++;
                            if (count == 2)
                                break;
                        }

                        global.each_composition[global.top] = global.each_composition[global.top] + global.title[global.top];
                    }
                }

                if (global.top == -1)
                    global.top++;
                global.each_composition[global.top] = global.each_composition[global.top] + total_result[i];
            }

            /*sava word*/
            total_result = result1.ToLower() + result2.ToLower() + result3.ToLower();
            String[] ar = total_result.Split(' ', '\n');
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < ar[i].Length; j++)
                {
                    if ((!(ar[i][j] >= 'a' && ar[i][j] <= 'z')) && ar[i][j] != '\n' && ar[i][j] != '-')
                    {
                        ar[i] = ar[i].Remove(j, 1);
                        j--;
                    }
                }
            }

            /*remove stopword*/
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < stopword.Length; j++)
                {
                    if (ar[i] == "\n" || ar[i] == stopword[j])
                    {
                        Array.Clear(ar, i, 1);
                        break;
                    }
                }
            }

            /*remove duplicate word and save in the result*/
            List<string> resultList = new List<string>();
            foreach (string Data in ar)
            {
                if (!resultList.Contains(Data))
                {
                    resultList.Add(Data);
                }
            }


            /*final word in the result*/
            string[] result = resultList.ToArray();
            Array.Sort(result);

            /*ar ,result1, result2, result3, resultList are released*/
            ar = null;
            result1 = null;
            result2 = null;
            result3 = null;
            resultList = null;
            GC.Collect();

            /*Now, result which save word
                   each_composition save all content
                   title save the title of each_composition*/

            /*initializate the he*/
            global.he = new Header[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                global.he[i] = new Header();
                global.he[i].add(result[i]);
            }

            /*build node*/
            /*i present chapter*/
            // Console.WriteLine(top);
            for (int i = 0; i <= global.top; i++)
            {
                /*remove punctuation*/
                string store_composition = global.each_composition[i].ToLower();
                for (int j = 0; j < store_composition.Length; j++)
                {
                    if ((!(store_composition[j] >= 'a' && store_composition[j] <= 'z')) && store_composition[j] != '\n' && store_composition[j] != ' ' && store_composition[j] != '-')
                    {
                        store_composition = store_composition.Remove(j, 1);
                        j--;
                    }
                }

                /*spilt*/

                string[] store_ar = store_composition.Split(' ', '\n');

                for (int k = 0; k < store_ar.Length; k++)
                {

                    for (int z = 0; z < result.Length; z++)
                    {
                        if ((store_ar[k] == global.he[z].word))
                        {
                            Node new_node = new Node();
                            new_node.count = 1;
                            new_node.chpter = i;
                            new_node.node_next = null;
                            global.he[z].add_node(new_node);
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                global.he[i].cal_tf(global.top + 1);
                /*//Console.Write("{0} {1} {2}->", he[i].total, he[i].word, he[i].dif);
                //int a = he[i].print();
                if (a != he[i].total)
                    Console.ReadKey();
                Console.Write("\n");*/
            }

            global.ch_vector = new vector[global.top + 1];
            for (int i = 0; i <= global.top; i++)
            {
                global.ch_vector[i] = new vector();
            }


            for (int i = 0; i <= global.top; i++)
            {

                global.ch_vector[i].cal_vector(global.he, result.Length, i);
                global.ch_vector[i].distance = Math.Sqrt(global.ch_vector[i].distance);
                //global.ch_vector[i].print();
                //Console.WriteLine();
            }

            label1.Text = "資料已建好";

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
                linkLabel1.Text = "1. ";
                linkLabel2.Text = "2. ";
                linkLabel3.Text = "3. ";
                linkLabel4.Text = "4. ";
                linkLabel5.Text = "5. ";
                linkLabel7.Text = "6. ";
                linkLabel9.Text = "7. ";
                linkLabel8.Text = "8. ";
                linkLabel10.Text = "9. ";
                linkLabel6.Text = "10. ";

            global.s = textBox4.Text;
            global.s = global.s.ToLower();

            vector query = new vector();
            for (int i = 0; i < global.he.Length; i++)
            {
                if (global.he[i].word == global.s)
                {
                    query.id = i;
                    query.dif = global.he[i].dif;
                    query.tf_dif = global.he[i].dif;
                    //Console.Write(global.he[i].dif);
                    query.distance = query.tf_dif;
                }
            }

            double[] cos = new double[global.top + 1];
            global.index = new int[global.top + 1];
            for (int i = 0; i <= global.top; i++)
            {
                cos[i] = 0;
                global.index[i] = i;
            }
            Console.WriteLine(query.id);
            for (int i = 0; i <= global.top; i++)
            {
                vector cu = global.ch_vector[i];
                while (cu != null)
                {
                    //Console.WriteLine(cu.id);
                    if (cu.id == query.id)
                    {
                        //Console.WriteLine(cu.tf_dif);
                        cos[i] = cu.tf_dif * query.tf_dif;
                        break;
                    }
                    cu = cu.node_next;
                }
                Console.WriteLine("0.0 {0}", cos[i]);
                //Console.Write(global.ch_vector[i].distance);
                cos[i] = cos[i] / (global.ch_vector[i].distance * query.distance);
            }

            for (int i = 0; i <= global.top; i++)
            {
                for (int j = 0; j <= global.top; j++)
                {
                    if (cos[i] > cos[j])
                    {
                        double tmp = cos[i];
                        cos[i] = cos[j];
                        cos[j] = tmp;
                        int t = global.index[i];
                        global.index[i] = global.index[j];
                        global.index[j] = t;
                    }
                }
            }
            if(global.top >= 0)
                linkLabel1.Text = linkLabel1.Text + global.title[global.index[0]];
            if (global.top >= 1)
                linkLabel2.Text = linkLabel2.Text + global.title[global.index[1]];
            if (global.top >= 2)
                linkLabel3.Text = linkLabel3.Text + global.title[global.index[2]];
            if (global.top >= 3)
                linkLabel4.Text = linkLabel4.Text + global.title[global.index[3]];
            if (global.top >= 4)
                linkLabel5.Text = linkLabel5.Text + global.title[global.index[4]];
            if (global.top >= 5)
                linkLabel7.Text = linkLabel7.Text + global.title[global.index[5]];
            if (global.top >= 6)
                linkLabel9.Text = linkLabel9.Text + global.title[global.index[6]];
            if (global.top >= 7)
                linkLabel8.Text = linkLabel8.Text + global.title[global.index[7]];
            if (global.top >= 8)
                linkLabel10.Text = linkLabel10.Text + global.title[global.index[8]];
            if (global.top >= 9)
                linkLabel6.Text = linkLabel6.Text + global.title[global.index[9]];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 0)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[0]];
                int top = 0, top_line = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                int[] line_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '\n')
                        line_index[top_line++] = i;
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                int top2 = 0;
                int top3 = 0;
                string[] print = global.each_composition[global.index[0]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if(i == line_index[top3])
                    {
                        richTextBox1.SelectedText = richTextBox1.SelectedText + "\n";
                        top3++;
                    }
                    if(i == store_index[top2])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top2++;
                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
                
            }
                
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 1)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[1]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[1]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }

            }
        }
        
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 2)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[2]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[2]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }

            }
        }
        

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 3)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[3]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[3]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
                
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 4)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[4]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[4]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
                
        }
        
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 5)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[5]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[5]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 6)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[6]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[6]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
                
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 7)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[7]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[7]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
        }
                
        

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 8)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[8]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[8]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (global.top >= 9)
            {
                richTextBox1.Text = "";
                string s = global.each_composition[global.index[9]];
                int top = 0;
                s = s.ToLower();

                int[] store_index = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(s[i] >= 'a' && s[i] <= 'z') && s[i] != ' ' && s[i] != '\n' && s[i] != '-')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                string[] ar = s.Split(' ');

                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == global.s)
                    {
                        store_index[top++] = i;
                    }
                }
                top = 0;
                string[] print = global.each_composition[global.index[9]].Split(' ');
                for (int i = 0; i < print.Length; i++)
                {
                    if (i == store_index[top])
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                        top++;

                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectedText = richTextBox1.SelectedText + " " + print[i];
                    }
                }
            }
        }
                
        
    }

    public class Node
    {
        public Node node_next;
        public int chpter;
        public int count;
        public double tf;
        public double tf_dif;
        public Node()
        {
            node_next = null;
            chpter = 0;
            tf = 0;
            tf_dif = 0;
        }
    }

    public class Header
    {
        public string word;
        public Node next;
        //public Object data;
        public int total;
        public double dif;
        public Header()
        {
            word = "";
            total = 0;
            next = null;
            dif = 0;
        }
        public void add(string a)
        {
            word = a;
            next = null;
            dif = 0;
        }

        public void add_node(Node n)
        {

            if (this.next == null)
            {
                next = n;
                this.total = 1;
            }
            else
            {

                bool ch = false;
                Node cu = this.next;
                while (cu.node_next != null)
                {
                    if (cu.chpter == n.chpter)
                    {
                        //Console.Write("030303");
                        cu.count++;
                        ch = true;
                        break;
                    }
                    //Console.Write("{0}\n", cu.chpter);
                    cu = cu.node_next;
                }
                if (cu.chpter == n.chpter && ch == false)
                {
                    cu.count++;
                    ch = true;
                }
                if (ch == false)
                {
                    if (cu.chpter == n.chpter)
                    {

                        Console.Write("0.0.");
                    }
                    cu.node_next = n;
                    n.node_next = null;
                    this.total++;
                    ch = true;
                }

            }
        }
        public int print()
        {
            int count = 0;
            Node cu = this.next;
            if (cu == null)
            {
                Console.Write("0.0");
                return 0;
            }
            else
            {
                while (cu != null)
                {
                    Console.Write("{0} {1} ", cu.tf, cu.count);
                    Console.Write("{0} ->", cu.chpter);
                    cu = cu.node_next;
                    count++;
                }
                return count;
            }
        }
        public void cal_tf(int top)
        {
            if (this.total != 0)
            {
                this.dif = Math.Log((double)top / (double)this.total, 2);
                if (this.dif == 0)
                    this.dif = 0.000000001;
                Node cu = this.next;
                while (cu != null)
                {
                    cu.tf = 1 + Math.Log((double)cu.count, 2);
                    cu.tf_dif = cu.tf * this.dif;
                    cu = cu.node_next;
                }
            }
        }


    }

    public class vector
    {
        public vector node_next;
        public int id;
        public double tf_dif;
        public double dif;
        public double distance;
        string word;
        public vector()
        {
            node_next = null;
            id = 0;
            tf_dif = 0;
            word = "";
            distance = 0;
        }

        public void cal_vector(Header[] he, int len, int chapter)
        {
            vector cu_v = null;
            for (int i = 0; i < len; i++)
            {
                Node cu = he[i].next;
                while (cu != null)
                {
                    if (cu.chpter == chapter)
                    {
                        vector new_node = new vector();
                        new_node.id = i;
                        new_node.tf_dif = cu.tf_dif;
                        new_node.word = he[i].word;
                        distance = distance + cu.tf_dif * cu.tf_dif;
                        if (node_next == null)
                        {
                            node_next = new_node;
                            cu_v = new_node;
                        }
                        else
                        {
                            cu_v.node_next = new_node;
                            cu_v = new_node;
                        }

                    }
                    cu = cu.node_next;
                }
            }
        }

        public void print()
        {
            vector cu = this.node_next;
            while (cu != null)
            {

                Console.Write("{0} ", cu.word);
                cu = cu.node_next;
            }
        }
    }
    class global
    {
        public static vector[] ch_vector;
        public static string[] title;
        public static string[] each_composition;
        public static int top = -1;
        public static Header[] he;
        public static int[] index;
        public static string s;
        public static void print_rich(int dex)
        {
            
        }
    }   
}

        

        

    

