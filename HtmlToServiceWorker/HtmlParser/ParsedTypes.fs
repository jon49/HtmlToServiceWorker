module ParsedTypes

type HTML = string

type Slot = { Name : string }

type ParentTemplate = { Path : string }

type TemplateChildType = Slot | HTML
type Template =
    { Name : string
      HtmlList : TemplateChildType list }

type TemplateLiteral =
    { Name : string
      Template : string }

type HtmlType =
    | HTML of HTML
    | Slot of Slot
    | ParentTemplate of ParentTemplate
    | Template of Template
    | TemplateLiteral of TemplateLiteral


