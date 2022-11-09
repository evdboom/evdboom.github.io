﻿using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.Line;
using Blog.PostComponents.Table;

namespace Blog.Builders
{
    public class TableBuilder : BuilderBase<TableBuilder, PostBuilder>
    {
        private readonly TableContent _content;

        private TableBuilder(PostBuilder parent, BlockType blockType, PositionType textAlignment, Style style) : base(parent, blockType, textAlignment, style)
        {
            _content = new();
            SetContentProperties(_content);
            SetContentProperties(_content.Columns);
        }

        public static TableBuilder CreateTable(PostBuilder parent, BlockType blockType, PositionType textAlignment, Style style)
        {
            return new TableBuilder(parent, blockType, textAlignment, style);
        }

        public TableBuilder WithCaption(string caption)
        {
            if (!string.IsNullOrEmpty(_content.Text))
            {
                throw new InvalidOperationException("Can only set caption once");
            }

            _content.Text = caption;
            return this;
        }

        public TableBuilder AddColumns(params string[] columnHeaders)
        {            
            foreach (var header in columnHeaders)
            {
                AddColumn(header);
            }

            return this;
        }

        private void AddColumn(string columnHeader)
        {
            var header = new LineContent
            {
                Text = columnHeader
            };
            SetContentProperties(header);
            _content.Columns.ChildContent.Add(header);
        }

        public TableBuilder AddRow(RowContent content)
        {
            _content.ChildContent.Add(content);
            SetContentProperties(content);
            return this;
        }

        public RowBuilder StartRow()
        {
            return RowBuilder.StartRow(this, _blockType, _textAlignment, _style);
        }

        protected override TableBuilder This()
        {
            return this;
        }

        protected override void OnBuild()
        {           
            if (!_content.ChildContent.All(c => c.ChildContent.Count == _content.Columns.ChildContent.Count))
            {
                throw new InvalidOperationException($"row parameter count must be equal to columns count ({_content.Columns.ChildContent.Count})");
            }

            _result.AddContent(_content);            
        }
    }
}
