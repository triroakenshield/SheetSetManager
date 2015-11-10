using System.Collections.Generic;
//

namespace SheetSetManager
{
    public abstract class AbstractSubset : MyNode
    {
        public List<Subset> subsetList;
        public List<Sheet> sheetList;

        public List<Sheet> GetAllSheet()
        {
            List<Sheet> resList = new List<Sheet>();
            resList.AddRange(this.sheetList);
            foreach (Subset ss in subsetList)
            {
                resList.AddRange(ss.GetAllSheet());
            }
            return resList;
        }

        public int GetAllSheetCount()
        {
            int res = sheetList.Count;
            foreach (Subset ss in subsetList)
            {
                res += ss.GetAllSheetCount();
            }
            return res;
        }

    }
}
