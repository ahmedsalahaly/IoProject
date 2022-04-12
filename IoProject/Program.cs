using System.IO; 

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello For Io System");

for (; ;)
{
    Console.WriteLine("what do you want?\n"+
        "1.Manage Folders\n" +
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
                        Console.WriteLine("Enter the date");
                        DateTime LastAccessDate = Convert.ToDateTime(Console.ReadLine());
                        if (!string.IsNullOrWhiteSpace(FolderPath))
                        {
                            if (Directory.Exists(FolderPath))
                            {
                                List<FolderReportDto> folderReportDtos = new List<FolderReportDto>();
                                List<FolderReportSize> foldersLessThans = new List<FolderReportSize>();
                                foreach (string FilePath in Directory.GetFiles(FolderPath))
                                {
                                    DateTime LastAccessDateOfFile = File.GetLastAccessTime(FilePath);

                                    if ((LastAccessDate > LastAccessDate))
                                    {
                                        folderReportDtos.(FilePath > LastAccessDateOfFile);
                                    }
                                    else
                                    {
                                        FolderReportDto.Where(FilePath < LastAccessDateOfFile);
                                    }
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
                    break;
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
    public List<FolderReportDto> Folders { get; set; }
}

public class FolderReportSize
{
    public List<FolderMoreThan> FolderMoreThans { get; set; }
    public List<FolderLessThan> FolderLessThans { get; set; }
}