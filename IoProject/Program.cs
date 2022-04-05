using System.IO; 

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello For Io System");

for (; ;)
{
    Console.WriteLine("what do you want?\n"+
        "1.Manage Folders\n +" +
        "2.close cmd\n");

    int MainAction = Convert.ToInt32(Console.ReadLine());
    if (MainAction == 1)

    {
        for (; ; )
        {
            Console.WriteLine("choose action\n" +
                "1.Report Folder\n"+
                "2.close cmd\n");
            int Action = Convert.ToInt32(Console.ReadLine());
            switch (Action)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Insert folder path");
                        string FolderPath = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(FolderPath))
                        {
                            if (Directory.Exists(FolderPath))
                            {
                                List<FolderReportDto> folderReportDtos = new List<FolderReportDto>();
                                foreach (string FilePath in Directory.GetFiles(FolderPath))
                                {
                                    string FileExtention = Path.GetExtension(FilePath);
                                    if (folderReportDtos.Any(x => x.ExtentionType == FileExtention))
                                    {
                                        folderReportDtos.Where(x => x.ExtentionType == FileExtention).FirstOrDefault()
                                            .ExtentionCount += 1;
                                    }
                                    else
                                    {
                                        FolderReportDto folderReportDto = new FolderReportDto();
                                        folderReportDto.ExtentionType = FileExtention;
                                        folderReportDto.ExtentionCount = 1;
                                        folderReportDtos.Add(folderReportDto);
                                    }
                                }
                                List<string> Lines = new List<string>();
                                foreach (FolderReportDto folderReportDto in folderReportDtos)
                                {
                                    string line = $"Extention type: {folderReportDto.ExtentionType} - " +
                                        $"Count: {folderReportDto.ExtentionCount}";
                                    Lines.Add(line);
                                }
                                string NameOfTXT = Path.Combine(FolderPath, $"Report.txt");
                                File.WriteAllLines(NameOfTXT, Lines);
                                Console.WriteLine($"Report has been generted on path:\n" +
                                    $"{NameOfTXT}\n\n");

                                for (int i = 0; i < Lines.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {Lines[i]}");
                                }

                            }
                            else
                            {
                                Console.WriteLine("you inserted wrong path");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please insert folder path");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.Beep();
                        Console.WriteLine($"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n");
                    }
                case 2:
                    break;
                default:
                    break;
            }
        }

    }
    else if (MainAction == 2)
    {
        break;
    }
}
public class FolderReportDto
{
    public string ExtentionType { get; set; }
    public int ExtentionCount { get; set; }
}