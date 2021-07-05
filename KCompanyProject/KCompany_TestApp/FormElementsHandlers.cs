using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCompany_TestApp
{
    public static class FormElementsHandlers
    {
        /// <summary>
        /// Clears TreeView nodes and fills it with departments structure from database
        /// </summary>
        /// <param name="addDepCode">Add or not department code to the end of its name </param>
        public static void DepartmentsTreeViewFillFromDB(TreeView tV, bool addDepCode = true)
        {
            using (var db = new TestDBEntities())
            {
                tV.BeginUpdate();
                tV.Nodes.Clear();

                int depCount = (from d in db.Department select d).Count();
                //Starting from the top layer (company)
                var currentDepartmentsLayer = (from d in db.Department
                                               where d.ParentDepartmentID == null
                                               orderby d.Name
                                               select d).ToList();

                foreach (var dep in currentDepartmentsLayer)
                {
                    string text = dep.Name;
                    if (addDepCode && dep.Code != string.Empty)
                        text += $" ({dep.Code})";
                    tV.Nodes.Add(dep.ID.ToString(), text);
                    --depCount;
                }

                while (depCount > 0)
                {
                    //Adds new layer of nodes
                    var nextDepartmentsLayer = new List<Department>();
                    foreach (var d in currentDepartmentsLayer)
                    {
                        var children = (from curDep in db.Department
                                        where curDep.ParentDepartmentID == d.ID
                                        orderby curDep.Name
                                        select curDep).ToArray();

                        if (children.Length == 0) continue;
                        string dKey = d.ID.ToString();
                        var dNode = tV.Nodes.Find(dKey, true);
                        foreach (var ch in children)
                        {
                            string text = ch.Name;
                            if (addDepCode && ch.Code != string.Empty)
                                text = $"{ch.Name} ({ch.Code})";
                            dNode[0].Nodes.Add(ch.ID.ToString(), text);
                            nextDepartmentsLayer.Add(ch);
                            --depCount;
                        }
                    }

                    //Updates current layer
                    currentDepartmentsLayer.Clear();
                    currentDepartmentsLayer.AddRange(nextDepartmentsLayer);
                }

                tV.EndUpdate();
            }
        }

        public static void SelectDepartmentNode(string nodeName, TreeView tV)
        {
            var selectedNodeInMainForm = tV.Nodes.Find(nodeName, true);
            if (selectedNodeInMainForm.Count() == 0) tV.SelectedNode = null;
            else tV.SelectedNode = selectedNodeInMainForm[0];
        }
    }
}
