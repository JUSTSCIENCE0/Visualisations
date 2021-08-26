namespace Visualisations
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tab4D = new System.Windows.Forms.TabPage();
            this.rotate4Dxy = new System.Windows.Forms.CheckBox();
            this.rotate4Dxz = new System.Windows.Forms.CheckBox();
            this.rotate4Dyz = new System.Windows.Forms.CheckBox();
            this.rotate4Dxd = new System.Windows.Forms.CheckBox();
            this.rotate4Dyd = new System.Windows.Forms.CheckBox();
            this.rotate4Dzd = new System.Windows.Forms.CheckBox();
            this.pic4D = new System.Windows.Forms.PictureBox();
            this.tabDrawing = new System.Windows.Forms.TabPage();
            this.drCurFigure = new System.Windows.Forms.ComboBox();
            this.valRotateZ = new System.Windows.Forms.NumericUpDown();
            this.valRotateY = new System.Windows.Forms.NumericUpDown();
            this.valRotateX = new System.Windows.Forms.NumericUpDown();
            this.DrRotateX = new System.Windows.Forms.CheckBox();
            this.DrRotateY = new System.Windows.Forms.CheckBox();
            this.DrRotateZ = new System.Windows.Forms.CheckBox();
            this.DrPicture = new System.Windows.Forms.PictureBox();
            this.tabPhysics = new System.Windows.Forms.TabPage();
            this.butAddForce = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.labGravMode = new System.Windows.Forms.Label();
            this.PhGrawMode = new System.Windows.Forms.NumericUpDown();
            this.labPhRadius = new System.Windows.Forms.Label();
            this.phRadius = new System.Windows.Forms.NumericUpDown();
            this.labPhMass = new System.Windows.Forms.Label();
            this.phMass = new System.Windows.Forms.NumericUpDown();
            this.butAddSphere = new System.Windows.Forms.Button();
            this.butPhStart = new System.Windows.Forms.Button();
            this.butPhPause = new System.Windows.Forms.Button();
            this.PhPicture = new System.Windows.Forms.PictureBox();
            this.Sorting = new System.Windows.Forms.TabPage();
            this.butShellSort = new System.Windows.Forms.Button();
            this.butQuickSort = new System.Windows.Forms.Button();
            this.butCombSort = new System.Windows.Forms.Button();
            this.butSortSelection = new System.Windows.Forms.Button();
            this.butSortMerge = new System.Windows.Forms.Button();
            this.butStSortInsert = new System.Windows.Forms.Button();
            this.butStSortBubble = new System.Windows.Forms.Button();
            this.StPicture = new System.Windows.Forms.PictureBox();
            this.Graph = new System.Windows.Forms.TabPage();
            this.ShortestWay = new System.Windows.Forms.Button();
            this.DebugText = new System.Windows.Forms.TextBox();
            this.SaveGraph = new System.Windows.Forms.Button();
            this.LoadGraph = new System.Windows.Forms.Button();
            this.SetWeights = new System.Windows.Forms.Button();
            this.DeletePoint = new System.Windows.Forms.Button();
            this.DisconnectPoints = new System.Windows.Forms.Button();
            this.ConnectPoints = new System.Windows.Forms.Button();
            this.AddPoint = new System.Windows.Forms.Button();
            this.GrPicture = new System.Windows.Forms.PictureBox();
            this.cur4DFig = new System.Windows.Forms.ComboBox();
            this.Tabs.SuspendLayout();
            this.tab4D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic4D)).BeginInit();
            this.tabDrawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valRotateZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valRotateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valRotateX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrPicture)).BeginInit();
            this.tabPhysics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhGrawMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhPicture)).BeginInit();
            this.Sorting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StPicture)).BeginInit();
            this.Graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tab4D);
            this.Tabs.Controls.Add(this.tabDrawing);
            this.Tabs.Controls.Add(this.tabPhysics);
            this.Tabs.Controls.Add(this.Sorting);
            this.Tabs.Controls.Add(this.Graph);
            this.Tabs.Location = new System.Drawing.Point(12, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1467, 632);
            this.Tabs.TabIndex = 0;
            // 
            // tab4D
            // 
            this.tab4D.Controls.Add(this.cur4DFig);
            this.tab4D.Controls.Add(this.rotate4Dxy);
            this.tab4D.Controls.Add(this.rotate4Dxz);
            this.tab4D.Controls.Add(this.rotate4Dyz);
            this.tab4D.Controls.Add(this.rotate4Dxd);
            this.tab4D.Controls.Add(this.rotate4Dyd);
            this.tab4D.Controls.Add(this.rotate4Dzd);
            this.tab4D.Controls.Add(this.pic4D);
            this.tab4D.Location = new System.Drawing.Point(4, 22);
            this.tab4D.Name = "tab4D";
            this.tab4D.Padding = new System.Windows.Forms.Padding(3);
            this.tab4D.Size = new System.Drawing.Size(1459, 606);
            this.tab4D.TabIndex = 4;
            this.tab4D.Text = "4D";
            this.tab4D.UseVisualStyleBackColor = true;
            // 
            // rotate4Dxy
            // 
            this.rotate4Dxy.AutoSize = true;
            this.rotate4Dxy.Location = new System.Drawing.Point(969, 6);
            this.rotate4Dxy.Name = "rotate4Dxy";
            this.rotate4Dxy.Size = new System.Drawing.Size(75, 17);
            this.rotate4Dxy.TabIndex = 9;
            this.rotate4Dxy.Text = "Rotate XY";
            this.rotate4Dxy.UseVisualStyleBackColor = true;
            // 
            // rotate4Dxz
            // 
            this.rotate4Dxz.AutoSize = true;
            this.rotate4Dxz.Location = new System.Drawing.Point(1050, 6);
            this.rotate4Dxz.Name = "rotate4Dxz";
            this.rotate4Dxz.Size = new System.Drawing.Size(75, 17);
            this.rotate4Dxz.TabIndex = 8;
            this.rotate4Dxz.Text = "Rotate XZ";
            this.rotate4Dxz.UseVisualStyleBackColor = true;
            // 
            // rotate4Dyz
            // 
            this.rotate4Dyz.AutoSize = true;
            this.rotate4Dyz.Location = new System.Drawing.Point(1131, 6);
            this.rotate4Dyz.Name = "rotate4Dyz";
            this.rotate4Dyz.Size = new System.Drawing.Size(75, 17);
            this.rotate4Dyz.TabIndex = 7;
            this.rotate4Dyz.Text = "Rotate YZ";
            this.rotate4Dyz.UseVisualStyleBackColor = true;
            // 
            // rotate4Dxd
            // 
            this.rotate4Dxd.AutoSize = true;
            this.rotate4Dxd.Location = new System.Drawing.Point(1213, 6);
            this.rotate4Dxd.Name = "rotate4Dxd";
            this.rotate4Dxd.Size = new System.Drawing.Size(76, 17);
            this.rotate4Dxd.TabIndex = 6;
            this.rotate4Dxd.Text = "Rotate XD";
            this.rotate4Dxd.UseVisualStyleBackColor = true;
            // 
            // rotate4Dyd
            // 
            this.rotate4Dyd.AutoSize = true;
            this.rotate4Dyd.Location = new System.Drawing.Point(1295, 6);
            this.rotate4Dyd.Name = "rotate4Dyd";
            this.rotate4Dyd.Size = new System.Drawing.Size(76, 17);
            this.rotate4Dyd.TabIndex = 5;
            this.rotate4Dyd.Text = "Rotate YD";
            this.rotate4Dyd.UseVisualStyleBackColor = true;
            // 
            // rotate4Dzd
            // 
            this.rotate4Dzd.AutoSize = true;
            this.rotate4Dzd.Location = new System.Drawing.Point(1377, 6);
            this.rotate4Dzd.Name = "rotate4Dzd";
            this.rotate4Dzd.Size = new System.Drawing.Size(76, 17);
            this.rotate4Dzd.TabIndex = 4;
            this.rotate4Dzd.Text = "Rotate ZD";
            this.rotate4Dzd.UseVisualStyleBackColor = true;
            // 
            // pic4D
            // 
            this.pic4D.BackColor = System.Drawing.Color.Transparent;
            this.pic4D.Location = new System.Drawing.Point(6, 24);
            this.pic4D.Name = "pic4D";
            this.pic4D.Size = new System.Drawing.Size(1446, 559);
            this.pic4D.TabIndex = 1;
            this.pic4D.TabStop = false;
            this.pic4D.Paint += new System.Windows.Forms.PaintEventHandler(this.pic4D_Paint);
            // 
            // tabDrawing
            // 
            this.tabDrawing.Controls.Add(this.drCurFigure);
            this.tabDrawing.Controls.Add(this.valRotateZ);
            this.tabDrawing.Controls.Add(this.valRotateY);
            this.tabDrawing.Controls.Add(this.valRotateX);
            this.tabDrawing.Controls.Add(this.DrRotateX);
            this.tabDrawing.Controls.Add(this.DrRotateY);
            this.tabDrawing.Controls.Add(this.DrRotateZ);
            this.tabDrawing.Controls.Add(this.DrPicture);
            this.tabDrawing.Location = new System.Drawing.Point(4, 22);
            this.tabDrawing.Name = "tabDrawing";
            this.tabDrawing.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrawing.Size = new System.Drawing.Size(1459, 606);
            this.tabDrawing.TabIndex = 3;
            this.tabDrawing.Text = "Drawing";
            this.tabDrawing.UseVisualStyleBackColor = true;
            // 
            // drCurFigure
            // 
            this.drCurFigure.FormattingEnabled = true;
            this.drCurFigure.Items.AddRange(new object[] {
            "Куб",
            "Цилиндр",
            "Шар",
            "Тор",
            "Плоскость",
            "Эллиптический параболоид"});
            this.drCurFigure.Location = new System.Drawing.Point(7, 15);
            this.drCurFigure.Name = "drCurFigure";
            this.drCurFigure.Size = new System.Drawing.Size(206, 21);
            this.drCurFigure.TabIndex = 7;
            this.drCurFigure.TextChanged += new System.EventHandler(this.drCurFigure_TextChanged);
            // 
            // valRotateZ
            // 
            this.valRotateZ.Location = new System.Drawing.Point(1161, 15);
            this.valRotateZ.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.valRotateZ.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.valRotateZ.Name = "valRotateZ";
            this.valRotateZ.Size = new System.Drawing.Size(58, 20);
            this.valRotateZ.TabIndex = 6;
            this.valRotateZ.ValueChanged += new System.EventHandler(this.valRotateZ_ValueChanged);
            // 
            // valRotateY
            // 
            this.valRotateY.Location = new System.Drawing.Point(1097, 15);
            this.valRotateY.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.valRotateY.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.valRotateY.Name = "valRotateY";
            this.valRotateY.Size = new System.Drawing.Size(58, 20);
            this.valRotateY.TabIndex = 5;
            this.valRotateY.ValueChanged += new System.EventHandler(this.valRotateY_ValueChanged);
            // 
            // valRotateX
            // 
            this.valRotateX.Location = new System.Drawing.Point(1033, 15);
            this.valRotateX.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.valRotateX.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.valRotateX.Name = "valRotateX";
            this.valRotateX.Size = new System.Drawing.Size(58, 20);
            this.valRotateX.TabIndex = 4;
            this.valRotateX.ValueChanged += new System.EventHandler(this.valRotateX_ValueChanged);
            // 
            // DrRotateX
            // 
            this.DrRotateX.AutoSize = true;
            this.DrRotateX.Location = new System.Drawing.Point(1225, 18);
            this.DrRotateX.Name = "DrRotateX";
            this.DrRotateX.Size = new System.Drawing.Size(68, 17);
            this.DrRotateX.TabIndex = 3;
            this.DrRotateX.Text = "Rotate X";
            this.DrRotateX.UseVisualStyleBackColor = true;
            this.DrRotateX.CheckedChanged += new System.EventHandler(this.DrRotateX_CheckedChanged);
            // 
            // DrRotateY
            // 
            this.DrRotateY.AutoSize = true;
            this.DrRotateY.Location = new System.Drawing.Point(1299, 18);
            this.DrRotateY.Name = "DrRotateY";
            this.DrRotateY.Size = new System.Drawing.Size(68, 17);
            this.DrRotateY.TabIndex = 2;
            this.DrRotateY.Text = "Rotate Y";
            this.DrRotateY.UseVisualStyleBackColor = true;
            this.DrRotateY.CheckedChanged += new System.EventHandler(this.DrRotateY_CheckedChanged);
            // 
            // DrRotateZ
            // 
            this.DrRotateZ.AutoSize = true;
            this.DrRotateZ.Location = new System.Drawing.Point(1373, 18);
            this.DrRotateZ.Name = "DrRotateZ";
            this.DrRotateZ.Size = new System.Drawing.Size(68, 17);
            this.DrRotateZ.TabIndex = 1;
            this.DrRotateZ.Text = "Rotate Z";
            this.DrRotateZ.UseVisualStyleBackColor = true;
            this.DrRotateZ.CheckedChanged += new System.EventHandler(this.DrRotateZ_CheckedChanged);
            // 
            // DrPicture
            // 
            this.DrPicture.BackColor = System.Drawing.Color.Transparent;
            this.DrPicture.Location = new System.Drawing.Point(7, 41);
            this.DrPicture.Name = "DrPicture";
            this.DrPicture.Size = new System.Drawing.Size(1446, 559);
            this.DrPicture.TabIndex = 0;
            this.DrPicture.TabStop = false;
            this.DrPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.DrPicture_Paint);
            // 
            // tabPhysics
            // 
            this.tabPhysics.Controls.Add(this.butAddForce);
            this.tabPhysics.Controls.Add(this.butClear);
            this.tabPhysics.Controls.Add(this.labGravMode);
            this.tabPhysics.Controls.Add(this.PhGrawMode);
            this.tabPhysics.Controls.Add(this.labPhRadius);
            this.tabPhysics.Controls.Add(this.phRadius);
            this.tabPhysics.Controls.Add(this.labPhMass);
            this.tabPhysics.Controls.Add(this.phMass);
            this.tabPhysics.Controls.Add(this.butAddSphere);
            this.tabPhysics.Controls.Add(this.butPhStart);
            this.tabPhysics.Controls.Add(this.butPhPause);
            this.tabPhysics.Controls.Add(this.PhPicture);
            this.tabPhysics.Location = new System.Drawing.Point(4, 22);
            this.tabPhysics.Name = "tabPhysics";
            this.tabPhysics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhysics.Size = new System.Drawing.Size(1459, 606);
            this.tabPhysics.TabIndex = 2;
            this.tabPhysics.Text = "Physics";
            this.tabPhysics.UseVisualStyleBackColor = true;
            // 
            // butAddForce
            // 
            this.butAddForce.Location = new System.Drawing.Point(112, 12);
            this.butAddForce.Name = "butAddForce";
            this.butAddForce.Size = new System.Drawing.Size(99, 23);
            this.butAddForce.TabIndex = 11;
            this.butAddForce.Text = "Add Force";
            this.butAddForce.UseVisualStyleBackColor = true;
            this.butAddForce.Click += new System.EventHandler(this.butAddForce_Click);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(1026, 12);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(42, 23);
            this.butClear.TabIndex = 10;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // labGravMode
            // 
            this.labGravMode.AutoSize = true;
            this.labGravMode.Location = new System.Drawing.Point(1341, 17);
            this.labGravMode.Name = "labGravMode";
            this.labGravMode.Size = new System.Drawing.Size(70, 13);
            this.labGravMode.TabIndex = 9;
            this.labGravMode.Text = "Gravity Mode";
            // 
            // PhGrawMode
            // 
            this.PhGrawMode.Location = new System.Drawing.Point(1417, 15);
            this.PhGrawMode.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PhGrawMode.Name = "PhGrawMode";
            this.PhGrawMode.Size = new System.Drawing.Size(36, 20);
            this.PhGrawMode.TabIndex = 8;
            // 
            // labPhRadius
            // 
            this.labPhRadius.AutoSize = true;
            this.labPhRadius.Location = new System.Drawing.Point(1074, 17);
            this.labPhRadius.Name = "labPhRadius";
            this.labPhRadius.Size = new System.Drawing.Size(40, 13);
            this.labPhRadius.TabIndex = 7;
            this.labPhRadius.Text = "Radius";
            // 
            // phRadius
            // 
            this.phRadius.Location = new System.Drawing.Point(1120, 15);
            this.phRadius.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.phRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.phRadius.Name = "phRadius";
            this.phRadius.Size = new System.Drawing.Size(58, 20);
            this.phRadius.TabIndex = 6;
            this.phRadius.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // labPhMass
            // 
            this.labPhMass.AutoSize = true;
            this.labPhMass.Location = new System.Drawing.Point(1184, 17);
            this.labPhMass.Name = "labPhMass";
            this.labPhMass.Size = new System.Drawing.Size(32, 13);
            this.labPhMass.TabIndex = 5;
            this.labPhMass.Text = "Mass";
            // 
            // phMass
            // 
            this.phMass.Location = new System.Drawing.Point(1222, 15);
            this.phMass.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.phMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.phMass.Name = "phMass";
            this.phMass.Size = new System.Drawing.Size(58, 20);
            this.phMass.TabIndex = 4;
            this.phMass.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // butAddSphere
            // 
            this.butAddSphere.Location = new System.Drawing.Point(7, 12);
            this.butAddSphere.Name = "butAddSphere";
            this.butAddSphere.Size = new System.Drawing.Size(99, 23);
            this.butAddSphere.TabIndex = 3;
            this.butAddSphere.Text = "Add Sphere";
            this.butAddSphere.UseVisualStyleBackColor = true;
            this.butAddSphere.Click += new System.EventHandler(this.butAddSphere_Click);
            // 
            // butPhStart
            // 
            this.butPhStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPhStart.ImageKey = "(отсутствует)";
            this.butPhStart.Location = new System.Drawing.Point(1286, 12);
            this.butPhStart.Name = "butPhStart";
            this.butPhStart.Size = new System.Drawing.Size(25, 23);
            this.butPhStart.TabIndex = 2;
            this.butPhStart.Text = "|>";
            this.butPhStart.UseVisualStyleBackColor = true;
            this.butPhStart.Click += new System.EventHandler(this.butPhStart_Click);
            // 
            // butPhPause
            // 
            this.butPhPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPhPause.ImageKey = "(отсутствует)";
            this.butPhPause.Location = new System.Drawing.Point(1310, 12);
            this.butPhPause.Name = "butPhPause";
            this.butPhPause.Size = new System.Drawing.Size(25, 23);
            this.butPhPause.TabIndex = 1;
            this.butPhPause.Text = "| |";
            this.butPhPause.UseVisualStyleBackColor = true;
            this.butPhPause.Click += new System.EventHandler(this.butPhPause_Click);
            // 
            // PhPicture
            // 
            this.PhPicture.Location = new System.Drawing.Point(6, 41);
            this.PhPicture.Name = "PhPicture";
            this.PhPicture.Size = new System.Drawing.Size(1447, 562);
            this.PhPicture.TabIndex = 0;
            this.PhPicture.TabStop = false;
            this.PhPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.PhPicture_Paint);
            this.PhPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PhPicture_MouseDoubleClick);
            this.PhPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PhPicture_MouseDown);
            this.PhPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PhPicture_MouseUp);
            // 
            // Sorting
            // 
            this.Sorting.Controls.Add(this.butShellSort);
            this.Sorting.Controls.Add(this.butQuickSort);
            this.Sorting.Controls.Add(this.butCombSort);
            this.Sorting.Controls.Add(this.butSortSelection);
            this.Sorting.Controls.Add(this.butSortMerge);
            this.Sorting.Controls.Add(this.butStSortInsert);
            this.Sorting.Controls.Add(this.butStSortBubble);
            this.Sorting.Controls.Add(this.StPicture);
            this.Sorting.Location = new System.Drawing.Point(4, 22);
            this.Sorting.Name = "Sorting";
            this.Sorting.Padding = new System.Windows.Forms.Padding(3);
            this.Sorting.Size = new System.Drawing.Size(1459, 606);
            this.Sorting.TabIndex = 1;
            this.Sorting.Text = "Sorting";
            this.Sorting.UseVisualStyleBackColor = true;
            // 
            // butShellSort
            // 
            this.butShellSort.Location = new System.Drawing.Point(538, 7);
            this.butShellSort.Name = "butShellSort";
            this.butShellSort.Size = new System.Drawing.Size(86, 23);
            this.butShellSort.TabIndex = 7;
            this.butShellSort.Text = "Sort Shell";
            this.butShellSort.UseVisualStyleBackColor = true;
            this.butShellSort.Click += new System.EventHandler(this.butShellSort_Click);
            // 
            // butQuickSort
            // 
            this.butQuickSort.Location = new System.Drawing.Point(446, 7);
            this.butQuickSort.Name = "butQuickSort";
            this.butQuickSort.Size = new System.Drawing.Size(86, 23);
            this.butQuickSort.TabIndex = 6;
            this.butQuickSort.Text = "Sort Quick";
            this.butQuickSort.UseVisualStyleBackColor = true;
            this.butQuickSort.Click += new System.EventHandler(this.butQuickSort_Click);
            // 
            // butCombSort
            // 
            this.butCombSort.Location = new System.Drawing.Point(354, 7);
            this.butCombSort.Name = "butCombSort";
            this.butCombSort.Size = new System.Drawing.Size(86, 23);
            this.butCombSort.TabIndex = 5;
            this.butCombSort.Text = "Sort Comb";
            this.butCombSort.UseVisualStyleBackColor = true;
            this.butCombSort.Click += new System.EventHandler(this.butCombSort_Click);
            // 
            // butSortSelection
            // 
            this.butSortSelection.Location = new System.Drawing.Point(262, 7);
            this.butSortSelection.Name = "butSortSelection";
            this.butSortSelection.Size = new System.Drawing.Size(86, 23);
            this.butSortSelection.TabIndex = 4;
            this.butSortSelection.Text = "Sort Selection";
            this.butSortSelection.UseVisualStyleBackColor = true;
            this.butSortSelection.Click += new System.EventHandler(this.butSortSelection_Click);
            // 
            // butSortMerge
            // 
            this.butSortMerge.Location = new System.Drawing.Point(181, 7);
            this.butSortMerge.Name = "butSortMerge";
            this.butSortMerge.Size = new System.Drawing.Size(75, 23);
            this.butSortMerge.TabIndex = 3;
            this.butSortMerge.Text = "Sort Merge";
            this.butSortMerge.UseVisualStyleBackColor = true;
            this.butSortMerge.Click += new System.EventHandler(this.butSortMerge_Click);
            // 
            // butStSortInsert
            // 
            this.butStSortInsert.Location = new System.Drawing.Point(89, 7);
            this.butStSortInsert.Name = "butStSortInsert";
            this.butStSortInsert.Size = new System.Drawing.Size(86, 23);
            this.butStSortInsert.TabIndex = 2;
            this.butStSortInsert.Text = "Sort Insertion";
            this.butStSortInsert.UseVisualStyleBackColor = true;
            this.butStSortInsert.Click += new System.EventHandler(this.butStSortInsert_Click);
            // 
            // butStSortBubble
            // 
            this.butStSortBubble.Location = new System.Drawing.Point(7, 7);
            this.butStSortBubble.Name = "butStSortBubble";
            this.butStSortBubble.Size = new System.Drawing.Size(75, 23);
            this.butStSortBubble.TabIndex = 1;
            this.butStSortBubble.Text = "Sort Bubble";
            this.butStSortBubble.UseVisualStyleBackColor = true;
            this.butStSortBubble.Click += new System.EventHandler(this.butStSortBubble_Click);
            // 
            // StPicture
            // 
            this.StPicture.Location = new System.Drawing.Point(6, 6);
            this.StPicture.Name = "StPicture";
            this.StPicture.Size = new System.Drawing.Size(1450, 597);
            this.StPicture.TabIndex = 0;
            this.StPicture.TabStop = false;
            this.StPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.StPicture_Paint);
            // 
            // Graph
            // 
            this.Graph.Controls.Add(this.ShortestWay);
            this.Graph.Controls.Add(this.DebugText);
            this.Graph.Controls.Add(this.SaveGraph);
            this.Graph.Controls.Add(this.LoadGraph);
            this.Graph.Controls.Add(this.SetWeights);
            this.Graph.Controls.Add(this.DeletePoint);
            this.Graph.Controls.Add(this.DisconnectPoints);
            this.Graph.Controls.Add(this.ConnectPoints);
            this.Graph.Controls.Add(this.AddPoint);
            this.Graph.Controls.Add(this.GrPicture);
            this.Graph.Location = new System.Drawing.Point(4, 22);
            this.Graph.Name = "Graph";
            this.Graph.Padding = new System.Windows.Forms.Padding(3);
            this.Graph.Size = new System.Drawing.Size(1459, 606);
            this.Graph.TabIndex = 0;
            this.Graph.Text = "Graph";
            this.Graph.UseVisualStyleBackColor = true;
            // 
            // ShortestWay
            // 
            this.ShortestWay.Location = new System.Drawing.Point(484, 6);
            this.ShortestWay.Name = "ShortestWay";
            this.ShortestWay.Size = new System.Drawing.Size(93, 23);
            this.ShortestWay.TabIndex = 10;
            this.ShortestWay.Text = "Shortest Way";
            this.ShortestWay.UseVisualStyleBackColor = true;
            this.ShortestWay.Click += new System.EventHandler(this.ShortestWay_Click);
            // 
            // DebugText
            // 
            this.DebugText.Location = new System.Drawing.Point(1293, 36);
            this.DebugText.Multiline = true;
            this.DebugText.Name = "DebugText";
            this.DebugText.Size = new System.Drawing.Size(160, 564);
            this.DebugText.TabIndex = 9;
            // 
            // SaveGraph
            // 
            this.SaveGraph.Location = new System.Drawing.Point(1297, 6);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(75, 23);
            this.SaveGraph.TabIndex = 8;
            this.SaveGraph.Text = "Save Graph";
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // LoadGraph
            // 
            this.LoadGraph.Location = new System.Drawing.Point(1378, 6);
            this.LoadGraph.Name = "LoadGraph";
            this.LoadGraph.Size = new System.Drawing.Size(75, 23);
            this.LoadGraph.TabIndex = 7;
            this.LoadGraph.Text = "Load Graph";
            this.LoadGraph.UseVisualStyleBackColor = true;
            this.LoadGraph.Click += new System.EventHandler(this.LoadGraph_Click);
            // 
            // SetWeights
            // 
            this.SetWeights.Location = new System.Drawing.Point(288, 6);
            this.SetWeights.Name = "SetWeights";
            this.SetWeights.Size = new System.Drawing.Size(75, 23);
            this.SetWeights.TabIndex = 6;
            this.SetWeights.Text = "Set Weights";
            this.SetWeights.UseVisualStyleBackColor = true;
            this.SetWeights.Click += new System.EventHandler(this.SetWeights_Click);
            // 
            // DeletePoint
            // 
            this.DeletePoint.Location = new System.Drawing.Point(369, 6);
            this.DeletePoint.Name = "DeletePoint";
            this.DeletePoint.Size = new System.Drawing.Size(75, 23);
            this.DeletePoint.TabIndex = 5;
            this.DeletePoint.Text = "DeletePoint";
            this.DeletePoint.UseVisualStyleBackColor = true;
            this.DeletePoint.Click += new System.EventHandler(this.DeletePoint_Click);
            // 
            // DisconnectPoints
            // 
            this.DisconnectPoints.Location = new System.Drawing.Point(179, 6);
            this.DisconnectPoints.Name = "DisconnectPoints";
            this.DisconnectPoints.Size = new System.Drawing.Size(103, 23);
            this.DisconnectPoints.TabIndex = 4;
            this.DisconnectPoints.Text = "Delete Connection";
            this.DisconnectPoints.UseVisualStyleBackColor = true;
            this.DisconnectPoints.Click += new System.EventHandler(this.DisconnectPoints_Click);
            // 
            // ConnectPoints
            // 
            this.ConnectPoints.Location = new System.Drawing.Point(87, 6);
            this.ConnectPoints.Name = "ConnectPoints";
            this.ConnectPoints.Size = new System.Drawing.Size(86, 23);
            this.ConnectPoints.TabIndex = 3;
            this.ConnectPoints.Text = "ConnectPoints";
            this.ConnectPoints.UseVisualStyleBackColor = true;
            this.ConnectPoints.Click += new System.EventHandler(this.ConnectPoints_Click);
            // 
            // AddPoint
            // 
            this.AddPoint.Location = new System.Drawing.Point(6, 6);
            this.AddPoint.Name = "AddPoint";
            this.AddPoint.Size = new System.Drawing.Size(75, 23);
            this.AddPoint.TabIndex = 2;
            this.AddPoint.Text = "AddPoint";
            this.AddPoint.UseVisualStyleBackColor = true;
            this.AddPoint.Click += new System.EventHandler(this.AddPoint_Click);
            // 
            // GrPicture
            // 
            this.GrPicture.Location = new System.Drawing.Point(6, 34);
            this.GrPicture.Name = "GrPicture";
            this.GrPicture.Size = new System.Drawing.Size(1280, 566);
            this.GrPicture.TabIndex = 0;
            this.GrPicture.TabStop = false;
            this.GrPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.GrPicture_Paint);
            this.GrPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrPicture_MouseDown);
            this.GrPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GrPicture_MouseMove);
            this.GrPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GrPicture_MouseUp);
            // 
            // cur4DFig
            // 
            this.cur4DFig.FormattingEnabled = true;
            this.cur4DFig.Items.AddRange(new object[] {
            "Тессеракт",
            "Гиперсфера"});
            this.cur4DFig.Location = new System.Drawing.Point(6, 3);
            this.cur4DFig.Name = "cur4DFig";
            this.cur4DFig.Size = new System.Drawing.Size(206, 21);
            this.cur4DFig.TabIndex = 10;
            this.cur4DFig.TextChanged += new System.EventHandler(this.cur4DFig_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 656);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Visualisations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.Tabs.ResumeLayout(false);
            this.tab4D.ResumeLayout(false);
            this.tab4D.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic4D)).EndInit();
            this.tabDrawing.ResumeLayout(false);
            this.tabDrawing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valRotateZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valRotateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valRotateX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrPicture)).EndInit();
            this.tabPhysics.ResumeLayout(false);
            this.tabPhysics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhGrawMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhPicture)).EndInit();
            this.Sorting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StPicture)).EndInit();
            this.Graph.ResumeLayout(false);
            this.Graph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Graph;
        private System.Windows.Forms.PictureBox GrPicture;
        private System.Windows.Forms.Button DeletePoint;
        private System.Windows.Forms.Button DisconnectPoints;
        private System.Windows.Forms.Button ConnectPoints;
        private System.Windows.Forms.Button AddPoint;
        private System.Windows.Forms.Button SaveGraph;
        private System.Windows.Forms.Button LoadGraph;
        private System.Windows.Forms.Button SetWeights;
        private System.Windows.Forms.TextBox DebugText;
        private System.Windows.Forms.Button ShortestWay;
        private System.Windows.Forms.TabPage Sorting;
        private System.Windows.Forms.PictureBox StPicture;
        private System.Windows.Forms.Button butStSortBubble;
        private System.Windows.Forms.Button butStSortInsert;
        private System.Windows.Forms.Button butSortMerge;
        private System.Windows.Forms.Button butSortSelection;
        private System.Windows.Forms.Button butCombSort;
        private System.Windows.Forms.Button butQuickSort;
        private System.Windows.Forms.Button butShellSort;
        private System.Windows.Forms.TabPage tabPhysics;
        private System.Windows.Forms.PictureBox PhPicture;
        private System.Windows.Forms.Button butPhStart;
        private System.Windows.Forms.Button butPhPause;
        private System.Windows.Forms.Button butAddSphere;
        private System.Windows.Forms.NumericUpDown phMass;
        private System.Windows.Forms.Label labPhRadius;
        private System.Windows.Forms.NumericUpDown phRadius;
        private System.Windows.Forms.Label labPhMass;
        private System.Windows.Forms.Label labGravMode;
        private System.Windows.Forms.NumericUpDown PhGrawMode;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butAddForce;
        private System.Windows.Forms.TabPage tabDrawing;
        private System.Windows.Forms.PictureBox DrPicture;
        private System.Windows.Forms.CheckBox DrRotateZ;
        private System.Windows.Forms.CheckBox DrRotateX;
        private System.Windows.Forms.CheckBox DrRotateY;
        private System.Windows.Forms.NumericUpDown valRotateZ;
        private System.Windows.Forms.NumericUpDown valRotateY;
        private System.Windows.Forms.NumericUpDown valRotateX;
        private System.Windows.Forms.ComboBox drCurFigure;
        private System.Windows.Forms.TabPage tab4D;
        private System.Windows.Forms.PictureBox pic4D;
        private System.Windows.Forms.CheckBox rotate4Dxd;
        private System.Windows.Forms.CheckBox rotate4Dyd;
        private System.Windows.Forms.CheckBox rotate4Dzd;
        private System.Windows.Forms.CheckBox rotate4Dxy;
        private System.Windows.Forms.CheckBox rotate4Dxz;
        private System.Windows.Forms.CheckBox rotate4Dyz;
        private System.Windows.Forms.ComboBox cur4DFig;
    }
}

