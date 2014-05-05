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

        public TTNode(TextBox _tb, TTNode _parent=null)
        {
            parent = _parent;
            tb = _tb;
            children = new List<TTNode>();
            x = _tb.Location.X;
            y = _tb.Location.Y;
            linesToChildren = new List<LineShape>();
            if (_parent == null)
                level = 0;
            else
                level = parent.level + 1;
            siblingDeleted = false;
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
                        child.x += 120;
                }
                if (parentTag == "L")
                {
                    if (tag == "L")
                        child.x -= 120;
                }
                if (parentTag == "C")
                {
                    if (tag == "L")
                        child.x -= 70;
                    if (tag == "R")
                        child.x += 70;
                }
                child.y = y + 55;
                if (tag == "C")
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
    }

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
