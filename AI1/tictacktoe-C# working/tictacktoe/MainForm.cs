/*
 * Created by SharpDevelop.
 * User: Reasearch Engineer
 * Date: 8/9/2010
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tictacktoe
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			reset();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		int[,] pos=new int[3,3];
	    int cnt,val,a,b,c=1,d=1,diff=1,vs=1;
	    char let;
	    String pl1="You",pl2="Computer";
	    Random rnd=new Random();
	    bool turn=true;
	    
	    void reset()
	    {
	        for (int i=0;i<3 ;i++ )
	        {
	            for (int j=0;j<3 ;j++ ){pos[i,j]=0;}
	        }
	        foreach(Control ctrl in this.Controls)
			{
				if (ctrl is Label) 
				{
					ctrl.ResetText();
				}
			}
	        cnt=0;
	        val=1;
	        let='X';
	        label10.Text=pl1+" to Play NOW.";
	    }
	     
	    bool play(int l,int m)
	    {
	        if(pos[l,m]==0)
	        {
	            a=c;b=d;c=l;d=m;
	            Label ctrl=link(l,m);
	            ctrl.Text=let.ToString();
	            pos[l,m]=val;
	            flip();
	            checkwin(l,m,pos[l,m]);
	            return true;
	        }
	        else
	            return false;
	    }
	    
	    Label link(int l,int m)
	    {
	        if(l==0)
	        {
	            if(m==0)
	                    return label1;
	            if(m==1)
	                    return label2;
	            if(m==2)
	                    return label3;
	        }
	        if(l==1)
	        {
	            if(m==0)
	                    return label6;
	            if(m==1)
	                    return label5;
	            if(m==2)
	                    return label4;
	        }
	        if(l==2)
	        {
	            if(m==0)
	                    return label9;
	            if(m==1)
	                    return label8;
	            if(m==2)
	                    return label7;
	        }
	        return null;
	    }

	    void flip()
	    {
	        if(let=='X')
	        {
	            let = 'O';
	            val=4;
	            cnt++;
	        }
	        else
	        {
	            let = 'X';
	            val=1;
	            cnt++;
	        }
	    }
	    
	    void checkwin(int l,int m,int n)
	    {
	        if(cnt==1)
	            if(vs==1)
	                turn=true;
	        if(cnt>4)
	        {
	            if((pos[l,0]+pos[l,1]+pos[l,2]==n*3)||(pos[0,m]+pos[1,m]+pos[2,m]==n*3))
	            {
	                cnt=n;
	            }
	            else
	            {
	                if((pos[0,0]+pos[1,1]+pos[2,2]==n*3)||(pos[2,0]+pos[1,1]+pos[0,2]==n*3))
	                {
	                    cnt=n;
	                }
	                else
	                {
	                    if(cnt==9)
	                    {
	                            cnt=0;
	                    }
	                }
	            }
	            if(cnt==1||cnt==0)
	            {
	                if(cnt==1)
	                    declare(pl1+" (Playing X) Wins!");
	                if(cnt==0)
	                    declare("The Game is a Draw!");
	                reset();
	                if(vs==1)
	                if(pl1=="Computer")
	                {
	                    turn=false;
	                    compplay(val);
	                }
	                else
	                    turn=false;
	               
	            }
	            else
	            if(cnt==4)
	            {
	                declare(pl2+" (Playing O) Wins!");
	                String temp=pl1;
	                pl1=pl2;
	                pl2=temp;
	                reset();
	                if(vs==1)
	                if(pl1=="Computer")
	                    compplay(val);
	                else
	                    turn=false;
	            }
	        }
	    }
	    
	    void declare(string stmt)
		{
			if(MessageBox.Show(stmt+" Do you want to continue?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)
			{
				Application.Exit();
			}
		}
	    
	     void compplay(int n)
	    {
	        bool carry=true;
	        if(diff==3)
	            carry=winorstop(a,b,n);
	        if((diff==2||diff==3) && carry)
	        {
	            if(n==1)
	                carry=winorstop(c,d,4);
	            else
	                carry=winorstop(c,d,1);
	        }
	        if(carry)
	                doany();
	    }
	     
	    bool winorstop(int l,int m,int n)
	    {
	        if(pos[l,0]+pos[l,1]+pos[l,2]==n*2)
	        {
	            for(int i=0;i<3;i++)
	            {
	                if(play(l,i))
	                    return false;
	            }
	        }
	        else
	            if(pos[0,m]+pos[1,m]+pos[2,m]==n*2)
	            {
	                for(int i=0;i<3;i++)
	                {
	                    if(play(i,m))
	                        return false;
	                }
	            }
	            else
	                if(pos[0,0]+pos[1,1]+pos[2,2]==n*2)
	                {
	                        for(int i=0;i<3;i++)
	                        {
	                                if(play(i,i))
	                                        return false;
	                        }
	                }
	                else
	                    if(pos[2,0]+pos[1,1]+pos[0,2]==n*2)
	                    {
	                            for(int i=0,j=2;i<3;i++,j--)
	                            {
	                                    if(play(i,j))
	                                            return false;
	                            }
	                    }
	
	        return true;
	    }
	
	    void doany()
	    {
	        int l=2,m=0;
	        switch(cnt)
	        {
	            case 0: play(0,0);
	                    break;
	            case 1: if(!(play(1,1)))
	                        play(0,0);
	                    break;
	            case 2: if(!(play(2,2)))
	                        play(0,2);
	                    break;
	            case 3: if((pos[0,1]+pos[1,1]+pos[2,1])==val)
	                        play(0,1);
	                    else
	                        if((pos[1,0]+pos[1,1]+pos[1,2])==val)
	                            play(1,0);
	                        else
	                            if(pos[0,1]!=0)
	                                play(0,2);
	                            else
	                                play(2,0);
	
	                    break;
	            default : while(!(play(l,m)))
	                      {
	                        l=rnd.Next(3);
	                        m=rnd.Next(3);
	                      }
	                    break;
	        }
	    }    
		
		void Label1Click(object sender, EventArgs e)
		{
			if(play(0,0)&&turn==true)
            compplay(val);
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			 if(play(0,1)&&turn==true)
            compplay(val);
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			if(play(0,2)&&turn==true)
            compplay(val);
		}
		
		void Label6Click(object sender, EventArgs e)
		{
			if(play(1,0)&&turn==true)
            compplay(val);
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			 if(play(1,1)&&turn==true)
            compplay(val);
		}
		
		void Label4Click(object sender, EventArgs e)
		{
			 if(play(1,2)&&turn==true)
            compplay(val);
		}
		
		void Label9Click(object sender, EventArgs e)
		{
			if(play(2,0)&&turn==true)
            compplay(val);
		}
		
		void Label8Click(object sender, EventArgs e)
		{
			if(play(2,1)&&turn==true)
            compplay(val);
		}
		
		void Label7Click(object sender, EventArgs e)
		{
			if(play(2,2)&&turn==true)
            compplay(val);
		}
			
		void EasyToolStripMenuItemClick(object sender, EventArgs e)
		{
			onlyone();
			easyToolStripMenuItem.Checked=true;
			diff=1;
		}
		
		void MediumToolStripMenuItemClick(object sender, EventArgs e)
		{
			onlyone();
			mediumToolStripMenuItem.Checked=true;
			diff=2;
		}
		
		void HardToolStripMenuItemClick(object sender, EventArgs e)
		{
			onlyone();
			hardToolStripMenuItem.Checked=true;
			diff=3;
		}
		
		void onlyone()
		{
			easyToolStripMenuItem.Checked=false;
			mediumToolStripMenuItem.Checked=false;
			hardToolStripMenuItem.Checked=false;
		}
		
		void VsComputerToolStripMenuItemClick(object sender, EventArgs e)
		{
			 pl1="You";
	        pl2="Computer";
	        reset();
	        vsComputerToolStripMenuItem.Checked=true;
	        vsPlayerToolStripMenuItem.Checked=false;
	        vs=1;
		}
		
		void VsPlayerToolStripMenuItemClick(object sender, EventArgs e)
		{
			 pl1="Player 1";
	        pl2="Player 2";
	        reset();
	        vsComputerToolStripMenuItem.Checked=false;
	        vsPlayerToolStripMenuItem.Checked=true;
	        vs=2;
	        turn=false;
		}
		
		void NewGameToolStripMenuItemClick(object sender, EventArgs e)
		{
			 if(vs==1)
	        {
	            pl1="You";
	            pl2="Computer";
	        }
	        else
	        {
	            pl1="Player 1";
	            pl2="Player 2";
	        }
	        reset();
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void HowToPlayToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("This is a  simple game  in which  Win  is achieved when\nthree consecutive blocks in a Row, Column or Diagonal\nare occupied before the opponent does the same.");
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Developer:BCA 6th Sem Student \nSubject: AI");
		}
	}
}
