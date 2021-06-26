using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

// Entity Relationship Debug,
// Displays graph of Entities
namespace LittleNecromancy
{
    class ERDebugState : GameState
    {
        private Dictionary<string, Entity> entities;
        private List<List<KeyValuePair<string, Entity>>> ERM;
        private const int xGap = 210;
        private const int yGap = 210;
        private const string boxSpriteFile = "titleText";

        public ERDebugState(Dictionary<string, Entity> stateEntities) : base()
        {
            entities = stateEntities;
            ERM = new List<List<KeyValuePair<string, Entity>>>();
        }

        public override void Initialize()
        {
            List<List<KeyValuePair<string, Entity>>> ERModelAssemblyHelper(List<List<KeyValuePair<string, Entity>>> ERModel, Dictionary<string, Entity> entities, int recurseNum)
            {
                bool dirtyFlag = false;
                ERModel.Add(new List<KeyValuePair<string, Entity>>());
                foreach (KeyValuePair<string, Entity> kvp in entities)
                {
                    if ((recurseNum == 0 && kvp.Value.GetParent() == null) || (recurseNum > 0 && ERModel[recurseNum - 1].Exists((x) => x.Value == kvp.Value.GetParent())))
                    {
                        ERModel[recurseNum].Add(kvp);
                        dirtyFlag = true;
                    }
                }
                if (dirtyFlag)
                    return ERModelAssemblyHelper(ERModel, entities, recurseNum + 1);
                else
                    return ERModel;
            }
            ERM = ERModelAssemblyHelper(ERM, entities, 0);
            RenderModel(ERM);
        }

        public void RenderModel(List<List<KeyValuePair<string, Entity>>> ERModel)
        {
            int runningX = 0;
            int runningY = 0;
            Entity container = new Entity();
            container.SetPosition(new Vector2(10, 10));
            AddEntity("container", container);
            foreach(List<KeyValuePair<string, Entity>> list in ERModel)
            {
                runningX = 0;
                foreach(KeyValuePair<string, Entity> kvp in list)
                {
                    Sprite box = new Sprite(boxSpriteFile);
                    box.SetParent(container);
                    box.SetPosition(new Vector2(runningX, runningY));
                    box.SetZ(1);
                    TextBox name = new TextBox("rainy", kvp.Key, Color.Black);
                    name.SetParent(box);
                    name.SetPosition(new Vector2(1, 1));
                    name.SetZ(2);
                    AddEntity(String.Concat("box", kvp.Key), box);
                    AddEntity(String.Concat("name", kvp.Key), name);
                    runningX += xGap;
                }
                runningY += yGap;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W)) cameraPosition -= Vector2.UnitY*4;
            if (Keyboard.GetState().IsKeyDown(Keys.S)) cameraPosition += Vector2.UnitY*4;
            if (Keyboard.GetState().IsKeyDown(Keys.A)) cameraPosition -= Vector2.UnitX*4;
            if (Keyboard.GetState().IsKeyDown(Keys.D)) cameraPosition += Vector2.UnitX*4;

        }
    }
}
