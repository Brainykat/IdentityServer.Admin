


using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer8.EntityFramework.Mappers;

internal static class AllowedSigningAlgorithmsConverter
{
    public static string Convert(ICollection<string> sourceMember)
    {
        if (sourceMember == null || !sourceMember.Any())
        {
            return null;
        }
        return sourceMember.Aggregate((x, y) => $"{x},{y}");
    }

    public static ICollection<string> Convert(string sourceMember)
    {
        var list = new HashSet<string>();
        if (!String.IsNullOrWhiteSpace(sourceMember))
        {
            sourceMember = sourceMember.Trim();
            foreach (var item in sourceMember.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct())
            {
                list.Add(item);
            }
        }
        return list;
    }
}
