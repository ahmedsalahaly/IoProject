using IoService.Dto;

namespace IoService
{
  public static class FolderService
  { 
    public static List<string> FolderReport(string FolderPath, out string ExeptionMassage)
    {
        ExeptionMassage = string.Empty;
        try
        {

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
                    string PathOfTextFile = Path.Combine(FolderPath, $"Report.txt");
                    File.WriteAllLines(PathOfTextFile, Lines);
                    return Lines;
                }
                else
                {
                    ExeptionMassage = "you inserted wrong path";
                    return null;
                }
            }
            else
            {
                ExeptionMassage = "Please insert folder path";
                return null;
            }

        }
        catch (Exception ex)
        {
            ExeptionMassage = $"Exeption: {ex.Message}\nDate of error: {DateTime.Now}\n\n";
            return null;
        }

    }
}
}
