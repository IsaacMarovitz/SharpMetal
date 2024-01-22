namespace SharpMetal.Generator.Instances
{
    public struct Documentation
    {
        /// <summary>
        /// <c>@abstract</c> or <c>@brief</c> Objective-C docs.
        /// </summary>
        public string? Summary;
        /// <summary>
        /// <c>@param</c> Objective-C docs.
        /// </summary>
        public Dictionary<string, string> Parameters;
        /// <summary>
        /// <c>@discussion</c> Objective-C docs.
        /// </summary>
        public string? Remarks;
        /// <summary>
        /// <c>@warning</c> Objective-C docs.
        /// </summary>
        public string? Warning;

        public Documentation(
            string summary,
            Dictionary<string, string> parameters,
            string remarks,
            string warning)
        {
            Summary = summary;
            Parameters = parameters;
            Remarks = remarks;
            Warning = warning;
        }

        public void Generate(CodeGenContext context)
        {
            if (Summary is not null)
            {
                context.WriteLine("/// <summary>");
                context.WriteLine($"/// {Summary}");
                context.WriteLine("/// </summary>");
            }

            foreach (var parameter in Parameters)
            {
                context.WriteLine($"/// <param name=\"{parameter.Key}\">{parameter.Value}</param>");
            }

            bool writingRemarks = (Remarks is not null) || (Warning is not null);

            if (writingRemarks)
            {
                context.WriteLine("/// <remarks>");
            }

            if (Remarks is not null)
            {

                context.WriteLine($"/// {Remarks}");
            }

            if (Warning is not null)
            {

                context.WriteLine($"/// WARNING: {Warning}");
            }

            if (writingRemarks)
            {
                context.WriteLine("/// </remarks>");
            }
        }
    }
}
