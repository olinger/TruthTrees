using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic.PowerPacks;

namespace TruthTreesGUI
{
    public class TTNode
    {
        public TTNode parent;
        public List<TTNode> children;
        public TextBox tb;
        public int x;
        public int y;
        public List<LineShape> linesToChildren;
        public LineShape lineToParent;
        public TTNode sibling;
        public CheckBox cb;
        public int level;
        public string tag;
        bool siblingDeleted;
        public string state;
        public int lineRef;

        public TTNode(TextBox _tb, TTNode _parent=null)
        {
            parent = _parent;
            tb = _tb;
            children = new List<TTNode>();
            x = _tb.Location.X;
            y = _tb.Location.Y;
            linesToChildren = new List<LineShape>();
            if (_parent == null)
                level = 1;
            else
                level += parent.level + 1;
            siblingDeleted = false;
            lineRef = 0;
        }

        public void delete()
        {
            foreach (TTNode child in children)
            {
                child.delete();
            }
            tb.Dispose();
            cb.Dispose();
            linesToChildren.Clear();
            if (lineToParent != null)
            {
                lineToParent.Dispose();
                lineToParent = null;
            }
            if (parent != null)
            {
                parent.linesToChildren.Clear();
            }
            if (sibling != null && !siblingDeleted)
            {
                siblingDeleted = true;
                sibling.delete();
            }
        }

        public void addChild(TTNode child)
        {
            children.Add(child);
        }
        public string getText()
        {
            return tb.Text;
        }

        public bool hasChild()
        {
            return (children.Count != 0);
        }

        public TTNode find(TextBox target)
        {
            if(this.tb==target) return this;
            foreach (TTNode child in children)
            {
                TTNode result = child.find(target);

                if (result != null)
                    return result;
            }
            return null;
        }

        public void reposition() //reposition the tree when a new child is added
        {
            foreach (TTNode child in children)
            {
                child.x = x;
                string parentTag = tb.Tag.ToString();
                string tag = child.tb.Tag.ToString();
                if (parentTag == "R")
                {
                    if (tag == "R")
                        child.x += 130;
                }
                if (parentTag == "L")
                {
                    if (tag == "L")
                        child.x -= 130;
                }
                if (parentTag == "C" || parentTag=="P")
                {
                    if (tag == "L")
                        child.x -= 80;
                    if (tag == "R")
                        child.x += 100;
                }
                child.y = y + 55;
                if (tag == "C" || tag=="P")
                {
                    child.y = y + 25;
                }
                if (child.hasChild())
                {
                    child.reposition();
                }
            }
        }

        public void drawLines() //draw lines connecting each parent to its children
        {
            foreach (TTNode child in this.children)
            {
                LineShape l = new LineShape();
                Point start = new Point(this.x+40,this.y+25);
                Point end = new Point(child.x+40,child.y);
                l.StartPoint = new System.Drawing.Point(start.X, start.Y);
                l.EndPoint = new System.Drawing.Point(end.X, end.Y);
                linesToChildren.Add(l);
                child.lineToParent = l;
                child.drawLines();
            }
        }

        public override string ToString()
        {
            return this.tb.Text;
        }

        public string ToString(bool r)
        {
            if (r)
            {
                string rule = "";
                if (tb.Tag.ToString() == "C")
                    rule = " d";
                else
                    rule = " b";
                return this.tb.Text + rule;
            }
            else return tb.Text;
        }

        public TTNode findByText(string target)
        {
            foreach (TTNode child in this.children)
            {
                string text = this.ToString();
                if (text == target)
                    return this;
                else
                    child.findByText(target);
            }
            return null;
        }

        public List<string> getLines(int i,List<string> lines)
        {
            foreach (TTNode child in children)
            {
                i++;
                string line = i + "; " + this.ToString() + "; ";
                string lvlString;
                if (level == 0)
                    lvlString = "None";
                else
                    lvlString = level.ToString();
                if (state != "Open" && state != "Closed")
                {
                    line += state + "; " + lvlString + "; ";
                    foreach (TTNode c in children)
                    {
                        line += c.level+1 + " ";
                    }
                }
                Console.WriteLine(line);
                lines.Add(line);
                lines.AddRange(child.getLines(i, lines));
            }
            return lines;
        }
        
        public string toTextFile(TTNode p)
        {
            string now = DateTime.Now.ToString("M-d-yy_H-mm");
            string fileName = "tree_" + now + ".txt";
            List<string> lines = new List<string>();
            System.IO.File.WriteAllLines(@fileName, lines);
            return fileName;
        }
    }
    /*
1; B & (H | Z); Premise; None; 2
2; ~z -> k; Premise; 1; 3
3; ~K; Premise; 2; 4 5
4; K; Branch 2; 3; 6
5; ~~Z; Branch 2; 3; 7
6; x; Closed 3 4; 4; None
7; z; Decomp 5; 5; 8
8; B; Decomp 1; 7; 9
9; H | z; Decomp 1; 8; 10 11
10; H; Branch 9; 9; 12
11; Z; Branch 9; 9; 13
12; o; Open; 10; None
13; o; Open; 11; None*/

    public class Line
    {
        public Point p1;
        public Point p2;

        public Line(Point point1, Point point2)
        {
            p1 = point1;
            p2 = point2;
        }

        public Line(int x1, int y1, int x2, int y2)
        {
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
        }
    }
}
