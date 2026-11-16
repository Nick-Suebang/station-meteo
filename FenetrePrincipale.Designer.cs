namespace station_meteo
{
    partial class FenetrePrincipale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.graphiqueTemperature = new ZedGraph.ZedGraphControl();
            this.graphiqueHumidite = new ZedGraph.ZedGraphControl();
            this.graphiqueDirectionVent = new ZedGraph.ZedGraphControl();
            this.graphiqueVitesseVent = new ZedGraph.ZedGraphControl();
            this.graphiquePression = new ZedGraph.ZedGraphControl();
            this.caseTemperature = new System.Windows.Forms.CheckBox();
            this.caseHumidite = new System.Windows.Forms.CheckBox();
            this.caseDirectionVent = new System.Windows.Forms.CheckBox();
            this.caseVitesseVent = new System.Windows.Forms.CheckBox();
            this.casePression = new System.Windows.Forms.CheckBox();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuTypeCapteur = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCapteurCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCapteurAleatoire = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            //
            // graphiqueTemperature
            //
            this.graphiqueTemperature.Location = new System.Drawing.Point(13, 95);
            this.graphiqueTemperature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphiqueTemperature.Name = "graphiqueTemperature";
            this.graphiqueTemperature.ScrollGrace = 0D;
            this.graphiqueTemperature.ScrollMaxX = 0D;
            this.graphiqueTemperature.ScrollMaxY = 0D;
            this.graphiqueTemperature.ScrollMaxY2 = 0D;
            this.graphiqueTemperature.ScrollMinX = 0D;
            this.graphiqueTemperature.ScrollMinY = 0D;
            this.graphiqueTemperature.ScrollMinY2 = 0D;
            this.graphiqueTemperature.Size = new System.Drawing.Size(476, 317);
            this.graphiqueTemperature.TabIndex = 0;
            this.graphiqueTemperature.UseExtendedPrintDialog = true;
            //
            // graphiqueHumidite
            //
            this.graphiqueHumidite.Location = new System.Drawing.Point(13, 420);
            this.graphiqueHumidite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphiqueHumidite.Name = "graphiqueHumidite";
            this.graphiqueHumidite.ScrollGrace = 0D;
            this.graphiqueHumidite.ScrollMaxX = 0D;
            this.graphiqueHumidite.ScrollMaxY = 0D;
            this.graphiqueHumidite.ScrollMaxY2 = 0D;
            this.graphiqueHumidite.ScrollMinX = 0D;
            this.graphiqueHumidite.ScrollMinY = 0D;
            this.graphiqueHumidite.ScrollMinY2 = 0D;
            this.graphiqueHumidite.Size = new System.Drawing.Size(476, 317);
            this.graphiqueHumidite.TabIndex = 1;
            this.graphiqueHumidite.UseExtendedPrintDialog = true;
            //
            // graphiqueDirectionVent
            //
            this.graphiqueDirectionVent.Location = new System.Drawing.Point(497, 95);
            this.graphiqueDirectionVent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphiqueDirectionVent.Name = "graphiqueDirectionVent";
            this.graphiqueDirectionVent.ScrollGrace = 0D;
            this.graphiqueDirectionVent.ScrollMaxX = 0D;
            this.graphiqueDirectionVent.ScrollMaxY = 0D;
            this.graphiqueDirectionVent.ScrollMaxY2 = 0D;
            this.graphiqueDirectionVent.ScrollMinX = 0D;
            this.graphiqueDirectionVent.ScrollMinY = 0D;
            this.graphiqueDirectionVent.ScrollMinY2 = 0D;
            this.graphiqueDirectionVent.Size = new System.Drawing.Size(476, 317);
            this.graphiqueDirectionVent.TabIndex = 2;
            this.graphiqueDirectionVent.UseExtendedPrintDialog = true;
            //
            // graphiqueVitesseVent
            //
            this.graphiqueVitesseVent.Location = new System.Drawing.Point(497, 420);
            this.graphiqueVitesseVent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphiqueVitesseVent.Name = "graphiqueVitesseVent";
            this.graphiqueVitesseVent.ScrollGrace = 0D;
            this.graphiqueVitesseVent.ScrollMaxX = 0D;
            this.graphiqueVitesseVent.ScrollMaxY = 0D;
            this.graphiqueVitesseVent.ScrollMaxY2 = 0D;
            this.graphiqueVitesseVent.ScrollMinX = 0D;
            this.graphiqueVitesseVent.ScrollMinY = 0D;
            this.graphiqueVitesseVent.ScrollMinY2 = 0D;
            this.graphiqueVitesseVent.Size = new System.Drawing.Size(476, 317);
            this.graphiqueVitesseVent.TabIndex = 3;
            this.graphiqueVitesseVent.UseExtendedPrintDialog = true;
            //
            // graphiquePression
            //
            this.graphiquePression.Location = new System.Drawing.Point(981, 259);
            this.graphiquePression.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphiquePression.Name = "graphiquePression";
            this.graphiquePression.ScrollGrace = 0D;
            this.graphiquePression.ScrollMaxX = 0D;
            this.graphiquePression.ScrollMaxY = 0D;
            this.graphiquePression.ScrollMaxY2 = 0D;
            this.graphiquePression.ScrollMinX = 0D;
            this.graphiquePression.ScrollMinY = 0D;
            this.graphiquePression.ScrollMinY2 = 0D;
            this.graphiquePression.Size = new System.Drawing.Size(476, 317);
            this.graphiquePression.TabIndex = 4;
            this.graphiquePression.UseExtendedPrintDialog = true;
            //
            // caseTemperature
            //
            this.caseTemperature.AutoSize = true;
            this.caseTemperature.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseTemperature.Location = new System.Drawing.Point(13, 61);
            this.caseTemperature.Name = "caseTemperature";
            this.caseTemperature.Size = new System.Drawing.Size(129, 27);
            this.caseTemperature.TabIndex = 5;
            this.caseTemperature.Text = "Température";
            this.caseTemperature.UseVisualStyleBackColor = true;
            this.caseTemperature.CheckedChanged += new System.EventHandler(this.CaseCapteur_CheckedChanged);
            //
            // caseHumidite
            //
            this.caseHumidite.AutoSize = true;
            this.caseHumidite.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseHumidite.Location = new System.Drawing.Point(191, 61);
            this.caseHumidite.Name = "caseHumidite";
            this.caseHumidite.Size = new System.Drawing.Size(166, 27);
            this.caseHumidite.TabIndex = 6;
            this.caseHumidite.Text = "Humidité relative";
            this.caseHumidite.UseVisualStyleBackColor = true;
            this.caseHumidite.CheckedChanged += new System.EventHandler(this.CaseCapteur_CheckedChanged);
            //
            // caseDirectionVent
            //
            this.caseDirectionVent.AutoSize = true;
            this.caseDirectionVent.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseDirectionVent.Location = new System.Drawing.Point(406, 61);
            this.caseDirectionVent.Name = "caseDirectionVent";
            this.caseDirectionVent.Size = new System.Drawing.Size(163, 27);
            this.caseDirectionVent.TabIndex = 7;
            this.caseDirectionVent.Text = "Direction du vent";
            this.caseDirectionVent.UseVisualStyleBackColor = true;
            this.caseDirectionVent.CheckedChanged += new System.EventHandler(this.CaseCapteur_CheckedChanged);
            //
            // caseVitesseVent
            //
            this.caseVitesseVent.AutoSize = true;
            this.caseVitesseVent.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseVitesseVent.Location = new System.Drawing.Point(605, 61);
            this.caseVitesseVent.Name = "caseVitesseVent";
            this.caseVitesseVent.Size = new System.Drawing.Size(150, 27);
            this.caseVitesseVent.TabIndex = 8;
            this.caseVitesseVent.Text = "Vitesse du vent";
            this.caseVitesseVent.UseVisualStyleBackColor = true;
            this.caseVitesseVent.CheckedChanged += new System.EventHandler(this.CaseCapteur_CheckedChanged);
            //
            // casePression
            //
            this.casePression.AutoSize = true;
            this.casePression.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casePression.Location = new System.Drawing.Point(799, 61);
            this.casePression.Name = "casePression";
            this.casePression.Size = new System.Drawing.Size(203, 27);
            this.casePression.TabIndex = 9;
            this.casePression.Text = "Pression barométrique";
            this.casePression.UseVisualStyleBackColor = true;
            this.casePression.CheckedChanged += new System.EventHandler(this.CaseCapteur_CheckedChanged);
            //
            // menuPrincipal
            //
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTypeCapteur});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1471, 28);
            this.menuPrincipal.TabIndex = 11;
                        //
            // menuTypeCapteur
            //
            this.menuTypeCapteur.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCapteurCsv,
            this.menuCapteurAleatoire});
            this.menuTypeCapteur.Name = "menuTypeCapteur";
            this.menuTypeCapteur.Size = new System.Drawing.Size(129, 24);
            this.menuTypeCapteur.Text = "Type de capteur";
            //
            // menuCapteurCsv
            //
            this.menuCapteurCsv.Name = "menuCapteurCsv";
            this.menuCapteurCsv.Size = new System.Drawing.Size(224, 26);
            this.menuCapteurCsv.Text = "Capteur CSV";
            this.menuCapteurCsv.Click += new System.EventHandler(this.MenuCapteurCsv_Click);
            //
            // menuCapteurAleatoire
            //
            this.menuCapteurAleatoire.Name = "menuCapteurAleatoire";
            this.menuCapteurAleatoire.Size = new System.Drawing.Size(224, 26);
            this.menuCapteurAleatoire.Text = "Capteur aléatoire";
            this.menuCapteurAleatoire.Click += new System.EventHandler(this.MenuCapteurAleatoire_Click);
            //
            // FenetrePrincipale
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 750);
            this.Controls.Add(this.casePression);
            this.Controls.Add(this.caseVitesseVent);
            this.Controls.Add(this.caseDirectionVent);
            this.Controls.Add(this.caseHumidite);
            this.Controls.Add(this.caseTemperature);
            this.Controls.Add(this.graphiquePression);
            this.Controls.Add(this.graphiqueVitesseVent);
            this.Controls.Add(this.graphiqueDirectionVent);
            this.Controls.Add(this.graphiqueHumidite);
            this.Controls.Add(this.graphiqueTemperature);
            this.Controls.Add(this.menuPrincipal);
            this.Name = "FenetrePrincipale";
            this.Text = "Station météo";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl graphiqueHumidite;
        private ZedGraph.ZedGraphControl graphiqueTemperature;
        private ZedGraph.ZedGraphControl graphiqueDirectionVent;
        private ZedGraph.ZedGraphControl graphiqueVitesseVent;
        private ZedGraph.ZedGraphControl graphiquePression;
        private System.Windows.Forms.CheckBox caseTemperature;
        private System.Windows.Forms.CheckBox caseHumidite;
        private System.Windows.Forms.CheckBox caseDirectionVent;
        private System.Windows.Forms.CheckBox caseVitesseVent;
        private System.Windows.Forms.CheckBox casePression;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuTypeCapteur;
        private System.Windows.Forms.ToolStripMenuItem menuCapteurCsv;
        private System.Windows.Forms.ToolStripMenuItem menuCapteurAleatoire;
    }
}
